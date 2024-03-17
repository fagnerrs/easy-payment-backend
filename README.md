<h1 align="center"> Easy Payment </h1>

<h2 align="center"> Programa de Pós Graduação - Arquitetura de Software Distribuído </h2>

<p align="center">
  <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQFfiu5r_DqXDQqIaH5XJ7lr3LQJWf478DDNw&usqp=CAU">
</p>

<h3 align="left"> Sobre o Projeto </h3>

Este projeto é resultado do trabalho de conclusão da pós graduação em Arquitetura de software distribuído,realizado na Puc Minas e finalizado no segundo semestre de 2023.

<h3 align="left"> Objetivos </h3>

- Desenvolver um arquitetura baseada em microserviços
- Fazer o deploy dos microserviços de forma simples em um cluster kubernetes
- Implementar escalabilitdade nos microserviços de acordo com a demanda de processamento 
- Implementar observabilidade sobre a infraestrutura e microserviços
- Disparar eventos no slack quando o sistema ultrapassar determinado valor de processamento

<h3 align="left"> Solução </h3>

- Os microserviços foram desenvolvido utilizando Asp.Net Core, seguindo as melhores práticas de design como arquitetura hexagonal
- O deployment dos microserviços foi automatizado utilizando a ferramenta Helm
- Foi implementado a função de horizontal pod autoscaling do kubernetes
- Foi implementada a ferramenta Prometheus e a geração de eventos customizados nos microserviços
- Foi implementada a ferramenta Alert Manager que gera eventos a partir das métricas do Prometheus
- Foi implementada a ferramenta Grafana para visualização de métricas
- Foi utilizada a ferramenta jMeter para teste de performance dos microserviços

<a href="https://drive.google.com/file/d/1plt3d7scslIfZeLujnIPw0CcJeskAIqk/view?usp=sharing">Relatório completo</a>
