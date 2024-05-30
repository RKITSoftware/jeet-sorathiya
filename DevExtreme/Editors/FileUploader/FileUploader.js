$(function () {

    $("#imgUploader").dxFileUploader({
        abortUpload: function (file, uploadInfo) {
            console.log(file);
            console.log(uploadInfo);
        }, // call when abort uploading at runtime
        accept: ".png,.txt,.exe", // show only this type of files in file manager
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        // allowedFileExtensions: ['.jpg', '.jpeg', '.gif', '.png'], // show all type of file but give error at upload time
        // allowCanceling: false // cancel at runtime
        chunkSize: 10000, // divide into chunks
        labelText: "Drop File Here", // change text
        multiple: true, // upload multiple file
        // call this function for each chunk
        uploadChunk: function (file, uploadInfo) {
            console.log("uploadChunk-file", file);
            console.log("uploadChunk-uploadInfo", uploadInfo);
        },
        // call after file upload (after onUploaded)
        onFilesUploaded: function (e) {
            console.log("onFilesUploaded-component", e.component);
            console.log("onFilesUploaded-element", e.element);
            console.log("onFilesUploaded-model", e.model);
        },
        //call for each chunk
        onProgress: function (e) {
            console.log("onProgress-bytesLoaded", e.bytesLoaded);
            console.log("onProgress-bytesTotal", e.bytesTotal);
            console.log("onProgress-component", e.component);
            console.log("onProgress-element", e.element);
            console.log("onProgress-event", e.event);
            console.log("onProgress-file", e.file);
            console.log("onProgress-request", e.request);
            console.log("onProgress-segmentSize", e.segmentSize);
            console.log("onProgress-model", e.model);
        },
        // call when upload cancel
        onUploadAborted: function (e) {
            console.log("onUploadAborted", e);
        },
        // call after file upload
        onUploaded: function (e) {
            console.log("onUploaded", e);
        },
        onUploadError: function (e) {
            console.log("onUploadError", e);
        },
        onValueChanged: function (e) {
            console.log("onValueChanged", e);
        }
    });

    const instDialogBox = $("#dialogBox").dxFileUploader({
        dialogTrigger: "#uploadImg", // trigger drop dialog
        dropZone: "#uploadImg", // create drop zone
        // dropZone: "#uploadImg", // for drag and drop
        visible: false,
        onUploadStarted: function (e) {
            console.log("onUploadStarted", e);
        },
        onBeforeSend: function (e) {
            console.log("onBeforeSend-component", e.component);
            console.log("onBeforeSend-element", e.element);
            console.log("onBeforeSend-file", e.file);
            console.log("onBeforeSend-model", e.model);
            console.log("onBeforeSend-request", e.request);
            console.log("onBeforeSend-uploadInfo", e.uploadInfo);
        },
        onDropZoneEnter: function (e) {
            console.log("onDropZoneEnter-component", e.component);
            console.log("onDropZoneEnter-dropZoneElement", e.dropZoneElement);
            console.log("onDropZoneEnter-element", e.element);
            console.log("onDropZoneEnter-event", e.event);
            console.log("onDropZoneEnter-model", e.model);
        },
        onDropZoneLeave: function (e) {
            console.log("onDropZoneLeave-component", e.component);
            console.log("onDropZoneLeave-dropZoneElement", e.dropZoneElement);
            console.log("onDropZoneLeave-element", e.element);
            console.log("onDropZoneLeave-event", e.event);
            console.log("onDropZoneLeave-model", e.model);
        },
        onProgress: function () {
            console.log("progress", instDialogBox.option("progress"));
        }
    }).dxFileUploader("instance");

    $("#useButton").dxFileUploader({
        uploadMode: "useButtons",
        abortUpload: function (file, uploadInfo) {
            console.log(file);
            console.log(uploadInfo);
        }, // call when abort uploading at runtime
        accept: ".png,.txt,.exe", // show only this type of files in file manager
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        // allowedFileExtensions: ['.jpg', '.jpeg', '.gif', '.png'], // show all type of file but give error at upload time
        // allowCanceling: false // cancel at runtime
        chunkSize: 10000, // divide into chunks
        labelText: "Drop File Here", // change text
        multiple: true, // upload multiple file
        // call this function for each chunk
        uploadChunk: function (file, uploadInfo) {
            console.log("uploadChunk-file", file);
            console.log("uploadChunk-uploadInfo", uploadInfo);
        },
        // call after file upload (after onUploaded)
        onFilesUploaded: function (e) {
            console.log("onFilesUploaded-component", e.component);
            console.log("onFilesUploaded-element", e.element);
            console.log("onFilesUploaded-model", e.model);
        },
        //call for each chunk
        onProgress: function (e) {
            console.log("onProgress-bytesLoaded", e.bytesLoaded);
            console.log("onProgress-bytesTotal", e.bytesTotal);
            console.log("onProgress-component", e.component);
            console.log("onProgress-element", e.element);
            console.log("onProgress-event", e.event);
            console.log("onProgress-file", e.file);
            console.log("onProgress-request", e.request);
            console.log("onProgress-segmentSize", e.segmentSize);
            console.log("onProgress-model", e.model);
        },
        // call when upload cancel
        onUploadAborted: function (e) {
            console.log("onUploadAborted", e);
        },
        // call after file upload
        onUploaded: function (e) {
            console.log("onUploaded", e);
        },
        onUploadError: function (e) {
            console.log("onUploadError", e);
        },
        onValueChanged: function (e) {
            console.log("onValueChanged", e);
        }
    });

    $("#file").dxFileUploader({
        uploadMode: "useForm"
    });

    const instAbort = $("#abort-file").dxFileUploader({
        uploadMode: "useButtons",
        multiple: true,
        accept: ".png,.txt,.exe", // show only this type of files in file manager
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        chunkSize: 100000, // divide into chunks
        uploadChunk: function () {
            const prog = instAbort.option("progress");
            if (prog >= 0) {
                // instAbort.abortUpload(1);
                instAbort.abortUpload(0);
                instAbort.removeFile(1);
            }
        },
        abortUpload: function (file, uploadInfo) {
            console.log(file);
            console.log(uploadInfo);
        }, // call when abort uploading at runtime
    }).dxFileUploader("instance");

  
    const instUpload = $("#upload-file").dxFileUploader({
        uploadMode: "useButtons",
        multiple: true,
        accept: ".png,.txt,.exe", // show only this type of files in file manager
        uploadUrl: 'https://js.devexpress.com/Demos/NetCore/FileUploader/Upload',
        chunkSize: 100000, // divide into chunks   
        onDropZoneEnter: uploadMyFile,
    }).dxFileUploader("instance");

    function uploadMyFile() {
        setTimeout(function () {
            instUpload.upload(0);
        }, 5000);      
        console.log("h")
    }

});

/* notes :
            isValid not working
*/
