$(function () {

    $("#imgUploader").dxFileUploader({
        abortUpload: function (file, uploadInfo) {
            console.log(file);
            console.log(uploadInfo);
        },
        accept:".png,.txt",
      //  allowedFileExtensions: ['.jpg', '.jpeg', '.gif', '.png'],
       // allowCanceling: false
    });

});