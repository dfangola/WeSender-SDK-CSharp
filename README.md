# WeSender SDK para C#
  SDK para conexão com a API em C#

**A chave da api deve ser passada na instância da classe, como construtor**

`Install-Package WeSenderSDK`

## Métodos diponiveis no momento
### - sendMessage
Esse metodo recebe um `payload` com as informações que devem ser enviadas e para quem deve ser enviado.
 ```cs

payload: {
  destine: List<string>,
  message: string,
  hasSpecialCharacter: bool // opcional, by default is false
}

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

## Autor
[Acidiney Dias](mailto:mailto:acidiney.dias@digitalfactory.co.ao)
