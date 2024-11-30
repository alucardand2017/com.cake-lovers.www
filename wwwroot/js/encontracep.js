const inputCep = document.getElementById("CepEndereco");
const inputComplemento = document.getElementById("ComplementoEndereco");
const inputLogradouro = document.getElementById("RuaEndereco");
const inputLocalidade = document.getElementById("CidadeEndereco");
const inputBairro = document.getElementById("BairroEndereco");
const inputEstado = document.getElementById("EstadoEndereco");


function EncontrarCep() {
    let cep = inputCep.value;

    var xhr = new XMLHttpRequest();
    xhr.open("GET", "https://viacep.com.br/ws/" + cep + "/json/");


    xhr.addEventListener("load", function () {
        var resposta = xhr.responseText;
        var respostaJSON = JSON.parse(resposta);
        console.log(respostaJSON);
        console.log(resposta);

        inputLogradouro.value = respostaJSON.logradouro;
        inputComplemento.value = respostaJSON.complemento;
        inputBairro.value = respostaJSON.bairro;
        inputLocalidade.value = respostaJSON.localidade;
        inputEstado.value = respostaJSON.estado;

    });
    xhr.send();
}

inputCep.addEventListener("focus", EncontrarCep);