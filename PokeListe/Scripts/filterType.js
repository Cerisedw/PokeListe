
$('.filterType').on('click', (target) => {
    console.log(target.currentTarget.id);
    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = () => {
        console.log(xhr.readyState);
        if (xhr.readyState === 4) {
            console.log(xhr.status);
            if (xhr.status === 200) {
                createVignettePoke(JSON.parse(xhr.response));
            }
        }
    };
    xhr.open("POST", `/Home/FilterByType/${target.currentTarget.id}`);
    xhr.send();
});


function createVignettePoke(arrayPoke) {
    $('#content').empty();
    console.log(arrayPoke);
    for (let i = 0; i < arrayPoke.length; i++) {
        console.log(arrayPoke[i]);
        vignette(arrayPoke[i]);
    }
}

function vignette(poke) {
    const div = $(`
    <div class="vignette">
        <a href="/Home/Get/${poke.IdPokemon}">
            <div><img src="/Content/Img/pokedex/${poke.Img}" /></div>
            <div><span>${poke.Numero}</span><h4>${poke.Nom}</h4></div>
        </a>
    </div>
    `);
    for (let j = 0; j < poke.Types.length; j++) {
    
        div.append(`
            <a href="/Home/GetType/${poke.Types[j].IdType}"><img src="/Content/Img/type/${poke.Types[j].Img}" /></a>
        `);
    }
    $("#content").append(div);
}