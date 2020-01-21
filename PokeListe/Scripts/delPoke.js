function isOk(string, target) {
    if (string === "OK") {
        $(target).removeClass('btn-primary').addClass('btn-danger');
        $(target).removeClass('delPoke').addClass('addPoke');
        $(target).html('Ajouter');
    }

}

function fonctionDeleteDB(target) {
    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = () => {
        console.log(xhr.readyState);
        if (xhr.readyState === 4) {
            console.log(xhr.status);
            if (xhr.status === 200) {
                isOk(xhr.statusText, target);
            }
        }
    };
    xhr.open("POST", `/Utilisateur/Home/DelPoke/${target.value}`);
    xhr.send();
};


$('.delPoke').on("click", (e) => {
    fonctionDeleteDB(e.target);
    //$(e.target).attr("disabled", true);
});

//console.log($(".addPoke"));

