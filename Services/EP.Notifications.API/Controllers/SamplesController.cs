using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace EP.Notifications.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SamplesController : ControllerBase
{
    private static readonly Histogram LoginDuration = Metrics
        .CreateHistogram("email_notification_duration_seconds", "Histogram to calculate processing durations.");
    
    private static readonly Counter ProcessedJobCount = Metrics
        .CreateCounter("email_notification_processed_total", "Number of processed jobs.");
    
    private static readonly Histogram OrderValueHistogram = Metrics
        .CreateHistogram("email_notification_reservation_pricess", "Histogram of received reservation prices.",
            new HistogramConfiguration
            {
                // We divide measurements in 10 buckets of $100 each, up to $1000.
                Buckets = Histogram.LinearBuckets(start: 100, width: 100, count: 10)
            });

    private static readonly Gauge JobsInQueue = Metrics
        .CreateGauge("email_notification_jobs_queued", "Number of jobs waiting for processing in the queue.");
    
    private static readonly Gauge DocumentImportsInProgress = Metrics
        .CreateGauge("email_notification_booking_progress", "Number of booking operations ongoing.");

    private static readonly Counter FailedDocumentImports = Metrics
        .CreateCounter("email_notification_imports_failed_total", "Number of operations that failed.");

    private async Task<int> RunRandomProcess()
    {
        var duration = new Random().Next(0, 5);
        await Task.Delay(TimeSpan.FromSeconds(new Random().Next(0, 5)));
        return duration;
    }
    
    
    [HttpGet("duration")]
    public async Task<IActionResult> Duration()
    {
        using (LoginDuration.NewTimer())
        {
            return Ok(RunRandomProcess());
        }
    }
    
    [HttpGet("counter")]
    public async Task<IActionResult> Counter()
    {
        await RunRandomProcess();
        ProcessedJobCount.Inc();

        return Ok();
    }
    
    [HttpPost("histogram/booking")]
    public async Task<IActionResult> Booking()
    {
        var resPrice = 0;
        using (DocumentImportsInProgress.TrackInProgress())
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            resPrice = new Random().Next(50, 1000);
            
            OrderValueHistogram.Observe(resPrice);
        }

        return Ok(resPrice);
    }
    
    [HttpPost("gauge/enqueue")]
    public async Task<IActionResult> GaugeEnqueue()
    {
        JobsInQueue.Inc();
        return Ok();
    }
    
    [HttpPost("gauge/dequeue")]
    public async Task<IActionResult> GaugeDequeue()
    {
        JobsInQueue.Dec();
        return Ok();
    }
    
    [HttpGet("/error")]
    public void GetError()
    {
        FailedDocumentImports.CountExceptions(() => throw new Exception("custom error"));
    }
}