
StoneChallenge - Payslip :star:
===============================

![Build status](https://github.com/ErickFeijo/StoneChallenge_Payslip/actions/workflows/build-test.yml/badge.svg?branch=master)
![Deploy status](https://github.com/ErickFeijo/StoneChallenge_Payslip/actions/workflows/docker-image.yml/badge.svg?branch=master)

## Descrição do desafio:
Na empresa existe um setor responsável pela contabilidade e pagamento de seus funcionários, entretanto, a parte contábil é realizada por uma consultoria externa. Gerir essas informações é algo bem importante e, dado que há uma confidencialidade no tráfego desses dados e também há uma possibilidade de economizar tirando essa consultoria do jogo, você foi escalado para criar uma aplicação responsável por criar o extrato da folha salarial dos funcionários. Esse extrato deve expôr o salário líquido do funcionário e todos os seus descontos discriminados.

## Possibilidades de utilização:
- Rodando com Visual Studio 2019 (Instalar o .NET SDK compatível) 
- Utilizando docker coforme as instruções no final desse arquivo 
- Chamando diretamente a [aplicação publicada no Azure](https://stonechallenge-payslip-api.azurewebsites.net/swagger/index.html)

## Tecnologias implementadas:

- ASP.NET 5.0 (com .NET 5.0)
- Entity Framework Core 5.0
- AutoMapper
- FluentValidator
- AutoFac
- Swagger UI
- XUnit
- MySql

## Comentários adicionais:
- A aplicação está com CI/CD utilizando GitHub Actions: (É possível visualizar [aqui](https://github.com/ErickFeijo/StoneChallenge_Payslip/actions))
  - Compilação
  - Execução dos testes
  - Publicação do container na Azure

## Docker:
É possível rodar a aplicação em docker. 

### Criando um multi-container com a API e o Banco de dados
Com o docker instalado na máquina, vá para a raiz do projeto e execute o seguinte comando:
```
docker-compose up
```
Com isso o docker irá seguir o script docker-compose.yml que está na raiz do projeto e irá rodar uma imagem com a API e outra com o Banco de dados MySql.

### Criando somente um container com a API e utilizando outro banco dados MySql
A aplicação precisa de um banco de dados MySql acessível e com permissões de escrita, leitura e criação. Os dados de acesso devem ser adicionados no arquivo Application/appsettings.json.
A base não precisa ter as tabelas criadas, a aplicação irá criar caso ainda não existam.

Com o docker instalado na máquina, vá para a raiz do projeto e execute o seguinte comando:
```
docker build -t payslip-api .
```
Com isso o docker irá compilar a aplicação seguindo o arquivo Dockerfile também na raiz do projeto
