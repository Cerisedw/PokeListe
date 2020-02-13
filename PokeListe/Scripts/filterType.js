
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
    arrayPoke.forEach(vignette);
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
    poke.Types.forEach((item) => {
        div.append(`
            <a href="/Home/GetType/${item.IdType}"><img src="/Content/Img/type/${item.Img}" /></a>
        `);
    });

    $("#content").append(div);
}