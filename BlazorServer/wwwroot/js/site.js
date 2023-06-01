function saveMessage(){
    //alert ("Save successfully!")
    Swal.fire(
        'Info!',
        'Save successfully',
        'success'
    )
}

function errorMessage(){
    //alert("Save error!")
    Swal.fire({
        title: 'Error!',
        text: 'Do you want to continue',
        icon: 'error',
        confirmButtonText: 'Cool'
    })
}

function download(base64String, fileName) {
    var fileDataUrl = "data:image/png;base64," + base64String;
    fetch(fileDataUrl)
        .then(resp => resp.blob())
        .then(blob => {
            var anchor = window.document.createElement("a");
            anchor.href = window.URL.createObjectURL(blob, { type: "image/png" });
            anchor.download = fileName;
            document.body.appendChild(anchor);
            anchor.click();
            document.body.removeChild(anchor);
        });
}


// JavaScript 為靜態檔，必須放置在 ~/wwwroot/ 底下。
