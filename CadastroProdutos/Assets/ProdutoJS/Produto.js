$(document).ready(function () {

    consultarProduto();
  

});

var id;


function consultarProduto() {
    
    requisicaoAssincrona("POST", "../Produto/ConsultaProduto", "", consultaSucesso, cadFalha)
}

function consultaSucesso(listProduto) {
    
    var produtos = JSON.parse(listProduto.obj)
    $('#bodyProduto').html("");

    $.each(produtos, function (i, obj) {

        var ativo = obj.Ativo == 1 ? "Ativo" : "Inativo"
        var Perecivel = obj.Perecivel == 1 ? "Sim" : "Não"

        switch (obj.CategoriaId) {

            case 1:
                obj.CategoriaId = "Eletrônico"
                break;
            case 2:
                obj.CategoriaId = "Informatica"
                break;
            case 3:
                obj.CategoriaId = "Celulares"
                break;
            case 4:
                obj.CategoriaId = "Moda"
                break;
            case 5:
                obj.CategoriaId = "Livros"
                break;
        }

        
        $('#bodyProduto').append(
            
            '<tr>\
                <th scope = "row" id="idProd">' + obj.Id+ '</th>\
            <td id="nomProd">' + obj.Nome + '</td>\
            <td id="descProd">' + obj.Descricao + '</td>\
            <td id="catProd">' + obj.CategoriaId + '</td>\
            <td id="atvProd">' + ativo + '</td>\
            <td id="perProd">' + Perecivel + '</td>\
            <td>\
                <button type="button" class="btn btn-success btnAtt">Atualizar</button>\
                <button type="button" class="btn btn-danger btnDel">Deletar</button>\
            </td>\
        </tr >'

        );



    });

    cadastrar();
    atualizarProduto();
    deletarProduto();
}

function cadastrar() {
    $("#btnCadastro").off('click');
    $("#btnCadastro").on("click", function () {

        let nome = $("#nome").val();
        let descricao = $("#descricao").val();
        let categoria = $("#categoria").val();

        if (nome.length <= 0 || descricao.length <= 0) {
            alert("Todos os campos devem estar preenchidos")
        } else {

        var cadastro = {
            Nome: nome,
            Descricao: descricao,
            CategoriaId: categoria,
            Perecivel: 0,
            Ativo: 1,
        }

            requisicaoAssincrona("POST", "../Produto/Cadastrar", cadastro, cadSucesso, cadFalha);

            
        }
        
    });
    
}


function atualizarProduto() {

    $('#bodyProduto').on('click', ".btnAtt", function (){

        $('#formCadastro').attr('hidden', true)
        $('#formAtualizar').attr('hidden', false)

        id = $(this).parent().parent().find('#idProd').html();
        let nomeAtt = $(this).parent().parent().find('#nomProd').html();
        let descricaoAtt = $(this).parent().parent().find('#descProd').html();
        let categoriaAtt = $(this).parent().parent().find('#catProd').html();
        
        $('#nomeAtt').val(nomeAtt);
        $('#descricaoAtt').val(descricaoAtt);
        $('#categoriaAtt').val(categoriaAtt);

        $('#btnAtt').on('click', function () {

            $('#formCadastro').attr('hidden', false)
            $('#formAtualizar').attr('hidden', true)

            let nome = $('#nomeAtt').val();
            let descricao = $('#descricaoAtt').val();
            let categoria = $('#categoriaAtt').val();
            
            var cadastro = {
                Id: id,
                Nome: nome,
                Descricao: descricao,
                CategoriaId: categoria,
                Perecivel: 0,
                Ativo: 1,
            }
            

            requisicaoAssincrona("POST", "../Produto/Atualizar", cadastro, cadSucesso, cadFalha);
        });
    });

}

function deletarProduto() {

    $('#bodyProduto').on('click', ".btnDel", function () {
        
         id = $(this).parent().parent().find('#idProd').html();

        json = {ID: id}

        requisicaoAssincrona("POST", "../Produto/Deletar", json, cadSucesso, cadFalha);

    });

}


function requisicaoAssincrona(tipo, url, obj, sucesso, falha) {
    $.ajax({
        type: tipo,
        url: url,
        async: true,
        data: JSON.stringify(obj),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (Json) {
            sucesso(Json);
        },
        error: function (Json) {
            falha(Json);
        }
    });
}


function cadFalha() {

    consultarProduto();
}


function cadSucesso() {

    consultarProduto();
}