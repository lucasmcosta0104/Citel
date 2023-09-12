var idCategoria;
var idProduto;


$("#btnSalvarProduto").click(function () {
    Spinner();
    var nome = document.getElementById("nome");
    var descricao = document.getElementById("descricao");
    var preco = document.getElementById("preco");
    var categoriaId = document.getElementById("categoria");

    if (nome.value == '') {
        hideSpinner();
        alert("Nome Obrigatório");
        return;
    } else if (descricao.value == '') {
        hideSpinner();
        alert("Descrição Obrigatória");
        return;
    } else if (preco.value == '') {
        hideSpinner();
        alert("Preço Obrigatório");
        return;
    } else if (categoriaId.value == '') {
        hideSpinner();
        alert("Categoria Obrigatória");
        return;
    }
    

    var command = {
        Id: idProduto ? idProduto : 0,
        Nome: nome.value,
        Descricao: descricao.value,
        Preco: preco.value,
        CategoriaId: categoriaId.value
    }
    if (idProduto) {
        $.ajax({
            type: 'PUT',
            url: '/Produto/EditarProduto',
            data: jsonToFormData(command),
            success: function () {
                idProduto = undefined;
                $("#formCadastroProduto").submit();
            },
            error: function () {
                alert('Erro ao inserir novo registro.');
            }
        });
    }
    else {
        $.ajax({
            type: 'POST',
            url: '/Produto/CadastraProduto',
            data: jsonToFormData(command),
            success: function () {
                $("#formCadastroProduto").submit();
            },
            error: function () {
                alert('Erro ao inserir novo registro.');
            }
        });
    }
    
    
});

$("#btnSalvarCategoria").click(function () {
    Spinner();
    var nome = document.getElementById("nome");
    var descricao = document.getElementById("descricao");

    if (nome.value == '') {
        hideSpinner();
        alert("Nome Obrigatório");
        return;
    } else if (descricao.value == '') {
        hideSpinner();
        alert("Descrição Obrigatória");
        return;
    }

    var command = {
        Id: idCategoria ? idCategoria : 0,
        Nome: document.getElementById("nome").value,
        Descricao: document.getElementById("descricao").value
    }
    if (idCategoria) {
        $.ajax({
            type: 'PUT',
            url: '/Categoria/EditarCategoria',
            data: jsonToFormData(command),
            success: function () {
                idCategoria = undefined;
                $("#formCadastroCategoria").submit();
            },
            error: function () {
                alert('Erro ao inserir novo registro.');
            }
        });
    }
    else {
        $.ajax({
            type: 'POST',
            url: '/Categoria/CadastraCategoria',
            data: jsonToFormData(command),
            success: function (data) {
                $("#formCadastroCategoria").submit();
            },
            error: function () {
                alert('Erro ao inserir novo registro.');
            }
        });
    }
});

function editarCategoria (id) {
    idCategoria = id;
    $.ajax({
        type: 'GET',
        url: '/Categoria/ObterCategoria/' + idCategoria,
        success: function (data) {
            document.getElementById("nome").value = data.nome;
            document.getElementById("descricao").value = data.descricao; 
            document.getElementById("categoriaModalLabel").textContent = 'Edição de Categorias'; 
        },
        error: function () {
            alert('Erro ao inserir novo registro.');
        }
    });
    
}

function removerCategoria () {
    $.ajax({
        type: 'DELETE',
        url: '/Categoria/Delete/' + idCategoria, 
        success: function (data) {
            fecharModal();
            location.reload();
        },
        error: function () {
            alert('Erro ao remover registro.');
        }
    });

}

function removerProduto() {
    $.ajax({
        type: 'DELETE',
        url: '/Produto/Delete/' + idProduto, // Substitua pelo URL correto do seu controlador
        success: function (data) {
            fecharModal();
            location.reload();
        },
        error: function () {
            alert('Erro ao remover registro.');
        }
    });

}

function abrirModal(id) {
    idCategoria = id;
    idProduto = id;
    var modal = document.getElementById('modal');
    modal.style.display = 'block';
}

function fecharModal() {
    var modal = document.getElementById('modal');
    modal.style.display = 'none';
}

function fecharModalCategoria () {
    var nome = document.getElementById("nome");
    nome.value = '';
    nome.disabled = false;
    var descricao = document.getElementById("descricao");
    descricao.value = '';
    descricao.disabled = false;
    document.getElementById("categoriaModalLabel").textContent = 'Inclusão de Categoria';
    document.getElementById("btnSalvarCategoria").style.display = 'flex';
}


function visualizarCategoria (id) {
    $.ajax({
        type: 'GET',
        url: '/Categoria/ObterCategoria/' + id, // Substitua pelo URL correto do seu controlador
        success: function (data) {
            var nome = document.getElementById("nome");
            nome.value = data.nome;
            nome.disabled = true;
            var descricao = document.getElementById("descricao");
            descricao.value = data.descricao;
            descricao.disabled = true;
            document.getElementById("categoriaModalLabel").textContent = 'Visualização de Categorias';
            document.getElementById("btnSalvarCategoria").style.display = 'none';

        },
        error: function () {
            alert('Erro ao inserir novo registro.');
        }
    });

}

function visualizarProduto(id) {
    $.ajax({
        type: 'GET',
        url: '/Produto/ObterProduto/' + id, // Substitua pelo URL correto do seu controlador
        success: function (data) {
            var nome = document.getElementById("nome");
            nome.value = data.nome;
            nome.disabled = true;
            var descricao = document.getElementById("descricao");
            descricao.value = data.descricao;
            descricao.disabled = true;
            var preco = document.getElementById("preco");
            preco.value = data.preco;
            preco.disabled = true;
            var categoria = document.getElementById("categoria");
            categoria.value = data.categoriaId;
            categoria.disabled = true;
            document.getElementById("produtoModalLabel").textContent = 'Visualização de Produto';
            document.getElementById("btnSalvarProduto").style.display = 'none';

        },
        error: function () {
            alert('Erro ao inserir novo registro.');
        }
    });

}

function editarProduto (id) {
    idProduto = id;
    $.ajax({
        type: 'GET',
        url: '/Produto/ObterProduto/' + idProduto, // Substitua pelo URL correto do seu controlador
        success: function (data) {
            document.getElementById("nome").value = data.nome;
            document.getElementById("descricao").value = data.descricao;
            document.getElementById("preco").value = data.preco;
            document.getElementById("categoria").value = data.categoriaId;
            document.getElementById("produtoModalLabel").textContent = 'Edição de Produto';

        },
        error: function () {
            alert('Erro ao inserir novo registro.');
        }
    });

}

function fecharModalProduto() {
    var nome = document.getElementById("nome");
    nome.value = '';
    nome.disabled = false;
    var descricao = document.getElementById("descricao");
    descricao.value = '';
    descricao.disabled = false;
    var preco = document.getElementById("preco");
    preco.value = 0;
    preco.disabled = false;
    var categoria = document.getElementById("categoria");
    categoria.value = 0;
    categoria.disabled = false;
    document.getElementById("produtoModalLabel").textContent = 'Inclusão de Produto';
    document.getElementById("btnSalvarProduto").style.display = 'flex';
}

function jsonToFormData(jsonData) {
    return Object.keys(jsonData)
        .map(key => encodeURIComponent(key) + '=' + encodeURIComponent(jsonData[key]))
        .join('&');
}

function hideSpinner() {
    const spinner = document.getElementById('spinner');
    spinner.style.display = 'none';
}

function Spinner() {
    const spinner = document.getElementById('spinner');
    spinner.style.display = 'flex';
}


document.addEventListener('DOMContentLoaded', hideSpinner);


$(document).ready(function () {
    $('#Categoria').DataTable({
        "language": {
            "lengthMenu": "Mostrando _MENU_ registros por página",
            "zeroRecords": "Nada encontrado",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "Nenhum registro disponível",
            "infoFiltered": "(filtrado de _MAX_ registros no total)"
        }
    });
});

$(document).ready(function () {
    $('#Produto').DataTable({
        "language": {
            "lengthMenu": "Mostrando _MENU_ registros por página",
            "zeroRecords": "Nada encontrado",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "Nenhum registro disponível",
            "infoFiltered": "(filtrado de _MAX_ registros no total)"
        }
    });
});
