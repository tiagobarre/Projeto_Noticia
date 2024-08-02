$(window).on("load", function () {
    LoadPage()
});

$('#submit').on('click', function () {
    var employee = new Object();
    employee.Titulo = $('#titulo').val();
    employee.Texto = $('#noticia').val();
    employee.UsuarioId = 1;
    employee.Id = $('#submit').val();

    $.ajax({
        type: 'POST',
        url: 'https://localhost:44375/CreateNoticia',
        data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {

        LoadPage();

    })

});

$('#submitTag').on('click', function () {
    var employee = new Object();
    employee.Descricao = $('#descricaoTag').val();
    employee.Id = $('#submitTag').val();
 
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44375/CreateTag',
        data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {

        LoadPage();

    })

});

$('#submitTagNoticia').on('click', function () {
    var employee = new Object();
    employee.NoticiaId = $('#noticiaId').val();
    employee.TagId = $('#tagId').val();
    employee.Id = $('#submitTagNoticia').val();
 
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44375/CreateNoticiaTag',
        data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {

        LoadPage();

    })

});

function LoadPage() {
    LimparCampos();
    LimparCamposTag();
    LimparCamposTagNoticia();
    $('#form').empty();
    $('#formTag').empty();
    $('#formTagNoticia').empty();
    $.ajax({
        type: "GET",
        url: 'https://localhost:44375/GetAllNoticia',
        success: function (data) {
            $.each(data, function (key, value) {
                $('#form').append('<div class="card text-bg-primary mb-3" style="max-width: 18rem; background-color:wheat">' +
                    '<div class= "card-header">' +
                    '<button type="button" class="btn btn-danger" value="' + value.id + '" onclick="deleteNoticia(' + value.id + ')"><i class="bi bi-trash"></i></button>&nbsp;' +
                    '<button type="button" class="btn btn-primary" value="' + value.id + '" onclick="EditarNoticia(' + value.id + ')"><i class="bi bi-pen"></i></button>' +
                    '</div>' +
                    '<div class= "card-body">' +
                    '<h5 class="card-title">' + value.titulo + '</h5>' +
                    '<p class= "card-text"> ' + value.texto + '</p></div></div>&nbsp;');
            });

        }
    });
    
    $.ajax({
        type: "GET",
        url: 'https://localhost:44375/GetAllTags',
        success: function (data) {
            $.each(data, function (key, value) {
                $('#formTag').append('<div class="card text-bg-primary mb-3" style="max-width: 18rem; background-color:wheat">' +
                    '<div class= "card-header">' +
                    '<button type="button" class="btn btn-danger" value="' + value.id + '" onclick="deleteTag(' + value.id + ')"><i class="bi bi-trash"></i></button>&nbsp;' +
                    '<button type="button" class="btn btn-primary" value="' + value.id + '" onclick="EditarTag(' + value.id + ')"><i class="bi bi-pen"></i></button>' +
                    '</div>' +
                    '<div class= "card-body">' +
                    '<p class= "card-text"> ' + value.descricao + '</p></div></div>&nbsp;');
            });

        }
    });

    $.ajax({
        type: "GET",
        url: 'https://localhost:44375/GetAllNoticiaTag',
        success: function (data) {
            $.each(data, function (key, value) {
                $('#formTagNoticia').append('<div class="card text-bg-primary mb-3" style="max-width: 18rem; background-color:wheat">' +
                    '<div class= "card-header">' +
                    '<button type="button" class="btn btn-danger" value="' + value.id + '" onclick="deleteTagNoticia(' + value.id + ')"><i class="bi bi-trash"></i></button>&nbsp;' +
                    '<button type="button" class="btn btn-primary" value="' + value.id + '" onclick="EditarTagNoticia(' + value.id + ')"><i class="bi bi-pen"></i></button>' +
                    '</div>' +
                    '<div class= "card-body">' +
                    '<p class= "card-text"> Noticia:' + value.noticiaId + '</p>Tag:' + value.tagId + '</div></div>&nbsp;'
                );
            });

        }
    });
    LimparCamposTagNoticia();
    LoadNoticiaTag();
}

function LoadNoticiaTag() {
    $.get("https://localhost:44375/GetAllTags", function (data) {
        $(data).each(function () {
            var tags = new Option(this.descricao, this.id);
            $('#tagId').append(tags);
        });
    });

    $.get("https://localhost:44375/GetAllNoticia", function (data) {
        $(data).each(function () {
            var tags = new Option(this.titulo, this.id);
            $('#noticiaId').append(tags);
        });
    });
}

function deleteNoticia(id) {

    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44375/DeteleNoticia?id=' + id + '',
        //data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {

        LoadPage();

    })
}

function deleteTag(id) {

    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44375/DeteleTag?id=' + id + '',
        //data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {

        LoadPage();

    })
}

function deleteTagNoticia(id) {

    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44375/DeteleTagNoticia?id=' + id + '',
        //data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {

        LoadPage();

    })
}

function EditarNoticia(id) {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44375/GetByIdNoticia?id=' + id + '',
        //data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {
        $('#titulo').val(data.titulo);
        $('#noticia').val(data.texto);
        $('#submit').val(data.id);
        $("#ModalCadastrarNoticias").modal('show');
    })
}

function EditarTag(id) {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44375/GetByIdTag?id=' + id + '',
        //data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {
        $('#descricaoTag').val(data.descricao);      
        $('#submitTag').val(data.id);
        $("#ModalCadastrarTag").modal('show');
    })
}

function EditarTagNoticia(id) {   

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44375/GetByIdTagNoticia?id=' + id + '',
        //data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {     
        $('#tagId').val(data.tagId);
        $('#noticiaId').val(data.noticiaId);
        $('#submitTagNoticia').val(data.id);
        $("#ModalCadastrarTagNoticia").modal('show');
    })
}

function LimparCampos() {
    $('#titulo').val('');
    $('#noticia').val('');
    $('#submit').val(0);

}

function LimparCamposTag() {
    $('#descricaoTag').val('');
    $('#submitTag').val(0);

}

function LimparCamposTagNoticia() {
    $('#noticiaId').empty();
    $('#tagId').empty();
    $('#submitTag').val(0);

}