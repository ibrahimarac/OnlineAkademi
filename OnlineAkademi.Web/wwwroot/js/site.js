
//JsonResponseStatus enum türüne karşılık gelen javascript

var Status = {
    Ok: 1,
    Error:2
}

$.ShowConfirm = function (title,content,okText,okAction) {

    $.confirm({
        title: title,
        content: content,
        type: 'blue',
        typeAnimated: true,
        closeIcon:true,
        buttons: {
            ok: {
                text: okText,
                btnClass: 'btn-red',
                action: okAction
            },
            cancel: {
                text: 'İptal',
                btnClass: 'btn-blue'
            }
        }
    });

}

$.ShowSuccess = function (title, content) {
    $.alert({
        title: title,
        content: content,
        closeIcon: true,
        type: 'green'
    });
}

$.ShowError = function (title, content) {
    $.alert({
        title: title,
        content: content,
        closeIcon: true,
        type: 'red'
    });
}

$.ShowWarning = function (title, content) {
    $.alert({
        title: title,
        content: content,
        closeIcon: true,
        type: 'orange'
    });
}

$.AjaxDelete = function (trigger, url) {

    var reqData = {
        id: $(trigger).data('id')
    }

    $.ajax({
        type: 'POST',
        url: url,
        data: JSON.stringify(reqData),
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result.status == Status.Ok) {
                $(trigger).parent().parent().hide(300, function () {
                    $(this).remove();
                    $.ShowSuccess('İşlem başarılı', result.message)
                })                
            }                
            if (result.status == Status.Error)
                $.ShowError('Hata oluştu',result.message)
        },
        error: function (xhr, status, error) {
            $.ShowError('Hata oluştu',error)
        }
    })
}
