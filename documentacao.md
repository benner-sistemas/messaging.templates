# Criar os seguintes projetos:

- Consumer: (dll) para regra de negócio que recebe a mensagem
- Producer: (web api) para o controller que recebe a mensagem via REST e enfileira
- Models: (dll) para domain objects, request/response, pocos
- Tests: (mstests ou xunit) para testes unitários em geral
- Integration.Tests: (xunit) para testes de integration, da API, por exemplo


## Consumer

- Adicionar os pacotes: 
 - Benner.Listener
 - Benner.Messaging
- Implementar uma classe especializando o EnterpriseIntegrationConsumerBase
- Implementar os métodos abstratos


## Models

- Adicionar os pacotes: 
 - Benner.Messaging
- Implementar uma classe especializando o IEnterpriseIntegrationResquest
- Implementar as propriedades {get;set;}


## Tests

- Adicionar referencia dos projetos Consumer, Models, e Producer
- Criar testes unitários para os objetos implementados nos projetos Consumer, Models e Producer


## Colocar o Consumer em Container


## Integration.Tests

- Adicionar referencia dos projetos Consumer, Models, e Producer
- Criar testes unitários para os objetos implementados nos projetos Consumer, Models e Producer