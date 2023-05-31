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


// JavaScript 為靜態檔，必須放置在 ~/wwwroot/ 底下。
