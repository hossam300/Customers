function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}

function downloadFromUrl(url, filename) {
    //var link = document.createElement('a');
    //link.download = fileName;
    //link.href = url;
    //document.body.appendChild(link); // Needed for Firefox
    //link.click();
    //document.body.removeChild(link);
    fetch(url).then(function (t) {
        return t.blob().then((b) => {
            var a = document.createElement("a");
            a.href = URL.createObjectURL(b);
            a.setAttribute("download", filename);
            a.click();
        }
        );
    });
}