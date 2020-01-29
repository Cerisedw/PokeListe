$(".actionPoke").on("click", (e) => {
    console.log(e.target.classList);
    (e.target.classList.value.search("addPoke") !== -1) ? fonctionClaimDB(e.target) : fonctionDeleteDB(e.target);
});


function fonctionClaimDB(target) {
    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = () => {
        console.log(xhr.readyState);
        if (xhr.readyState === 4) {
            console.log(xhr.status);
            if (xhr.status === 200) {
                changeClass(target);
            }
        }
    };
    xhr.open("POST", `/Utilisateur/Home/AddPoke/${target.value}`);

    xhr.send();
};

function changeClass(target) {
    $(target).removeClass('btn-danger').addClass('btn-primary');
    $(target).removeClass('addPoke').addClass('delPoke');
    $(target).html('Enlever');
}

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
