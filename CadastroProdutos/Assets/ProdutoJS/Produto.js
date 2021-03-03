$(document).ready(function () {

    cadastrar();


});

function cadastrar() {
    $("#btnCadastro").on("click", function () {

        let nome = $("#nome").val();
        let descricao = $("#descricao").val();
        let categoria = $("#categoria").val();
        let perecivel = $("#check").val();
        let categoriaId = 1

        if (nome.length <= 0 || descricao.length <= 0)
        {
            alert("Todos os campos devem estar preenchidos")
        }

        var cadastro = {
            Nome: nome,
            Descricao: descricao,
            Categoria: categoria,
            Perecivel: perecivel,
            CategoriaId: categoriaId
        }
        
        requisicaoAssincrona("POST", "../Produto/Cadastrar", cadastro, cadSucesso());
    });
}

function cadSucesso() {
    
}


function requisicaoAssincrona(tipo, url, obj, sucesso, falha) {
    
    $.ajax({
        url: url,
        type: tipo,
        dataType: "json",
        data: JSON.stringify(obj),
        contentType: 'application/json; charset=utf-8'
    })
        .done(function (msg) {
            sucesso
        })
        .fail(function (jqXHR, textStatus, msg) {
            falha
        });
}