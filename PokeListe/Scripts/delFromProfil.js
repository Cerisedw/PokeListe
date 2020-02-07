$(".delPoke").on("click", (e) => {
    console.log(e.target.classList);
    (e.target.classList.value.search("addPoke") !== -1) ? fonctionClaimDB(e.target) : fonctionDeleteDB(e.target);
});



function deleteRow(target) {
    $(target).parent().remove();
    const count = parseInt($("#pokeCount").text(), 10) - 1;
    $("#pokeCount").text(count);
}

function fonctionDeleteDB(target) {
    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = () => {
        console.log(xhr.readyState);
        if (xhr.readyState === 4) {
            console.log(xhr.status);
            if (xhr.status === 200) {
                deleteRow(target);
            }
        }
    };
    xhr.open("POST", `/Utilisateur/Home/DelPoke/${target.value}`);
    xhr.send();
};
