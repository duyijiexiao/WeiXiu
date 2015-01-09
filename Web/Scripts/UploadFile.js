function addFileUrl(url) {
   
    $('#addimg').append('<img height="72" style=" float:left; " width="72" alt="" src="' + url + '" />');
    $("#TuPian").val(url +','+ $("#TuPian").val());
    nubmax++;
}
var nubmax = 0;
var $ = jQuery, $list = $('#fileList');
var ValidateIndex;
var uploader = WebUploader.create({

    // 选完文件后，是否自动上传。
    auto:true,
    multiple: false,
   
    // swf文件路径
    swf: '~/Content/webuploader/Uploader.swf',

    // 文件接收服务端。
    server: '/1/FileUp/Index',

    // 选择文件的按钮。可选。
    // 内部根据当前运行是创建，可能是input元素，也可能是flash.
    pick: '#filePicker',
    resize: true,
    // 只允许选择图片文件。
    accept: {
        title: '图片文件',
        extensions: 'gif,jpg,jpeg,bmp,png',
        mimeTypes: 'image/*'
    },
    fileNumLimit: 1,
    fileSizeLimit:5 * 1024 * 1024,
    fileSingleSizeLimit: 5 * 1024 * 1024
});
uploader.on('beforeFileQueued', function (file) {
    if (nubmax>2) {
        alert("图片文件数量不能超过3");
        return false;
    }
    switch (file.ext.toLowerCase()) {
        case "gif": return true; break;
        case "jpg": return true; break;
        case "jpeg": return true; break;
        case "bmp": return true; break;
        case "png": return true; break;
    }
    alert("请选择图片文件");
    return false;
});
uploader.on('fileQueued', function (file) {
    var $li = $(
            '<div id="' + file.id + '" class="file-item thumbnail">' +
                '<img>' +
                '<div class="info">' + file.name + '</div>' +
            '</div>'
            ),
        $img = $li.find('img');


    // $list为容器jQuery实例
    $list.append($li);
});
 
// 文件上传成功，给item添加成功class, 用样式标记上传成功。
uploader.on('uploadSuccess', function (file, responseText) {
    //$('#' + file.id).remove();
    var validate;
    for (var d in responseText) {
        validate = responseText[d];
    }
    ValidateIndex = validate.indexOf("<script");
    if (ValidateIndex > 0) {
        $.messager.alert('提示', '登录超时');
    } else {
        
        addFileUrl(responseText.result);
    }
    uploader.reset();
});

// 文件上传失败，显示上传出错。
uploader.on('uploadError', function (file) {
    var $li = $('#' + file.id),
        $error = $li.find('div.error');

    // 避免重复创建
    if (!$error.length) {
        $error = $('<div class="error"></div>').appendTo($li);
    }

    $error.text('上传失败');
});

// 完成上传完了，成功或者失败，先删除进度条。
uploader.on('uploadComplete', function (file) {
    //$('#' + file.id).find('.progress').remove();
});
