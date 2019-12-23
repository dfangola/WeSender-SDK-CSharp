# WeSender SDK para C#
  SDK para conexão com a API em C#

**A chave da api deve ser passada na instância da classe, como construtor**

`Install-Package WeSenderSDK`

## Métodos diponiveis no momento
### - sendMessage
Esse metodo recebe `três parametros` com as informações que devem ser enviadas e para quem deve ser enviado.
 ```cs
SendMessage (List<string> destines, string message, bool hasSpecialCharacter = false)
 ``` 
Resposta do método é a mesma que a da API:
```cs

{
  "Success" : bool,
  "Message" : String,
}

```

## Exemplo

```cs
using WeSenderSDK;
var WSDK = new WeSender("apikey");
var destines = new List<string>();
destines.Add("920000000");
var response = WSDK.SendMessage(destines, "Olá Angola");
```

## License
MIT

## Contributors
[Erikson Melgarejo](mailto:mailto:erikson.melgarejo@digitalfactory.co.ao)

## Author
[Acidiney Dias](mailto:mailto:acidiney.dias@digitalfactory.co.ao)
