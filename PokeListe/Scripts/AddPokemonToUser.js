
function fonctionClaimDB (pokemonID) {
    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = () => {
        console.log(xhr.readyState);
        if (xhr.readyState === 4) {
            console.log(xhr.status);
            if (xhr.status === 200) {
                //console.log(xhr.responseText);
            }
        }
    };
    xhr.open("POST", `/Utilisateur/Home/AddPoke/${pokemonID}`);
    //let formulaire = new FormData();
    ////formulaire.append('IdUtilisateur', userId);
    //formulaire.append('IdPokemon', pokemonID);
    xhr.send();
};


$('.addPoke').on("click", (e) => {
    fonctionClaimDB(e.target.value);
    //$(e.target).attr("disabled", true);
    $(e.target).removeClass('btn-danger').addClass('btn-primary');
    $(e.target).removeClass('addPoke').addClass('delPoke');
    $(e.target).html('Supprimer');
});

//console.log($(".addPoke"));
