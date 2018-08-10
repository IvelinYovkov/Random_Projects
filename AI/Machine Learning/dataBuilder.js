function printData()
{
    console.log(newLocal);
    data = newLocal; 
    var html= " ";
    html += `<table style="width:100%">`;
    html += "<tr>";
    html += "<th>Name</th>";
    for(let key in data["movies"])
    {
        html += `<th> ${data["movies"][key]} </th>`;
    }
    html += "</tr>";
    for(let rates in data["ratings"])
    {
        html += "<tr>";
        html += "<td>" + rates + "</td>";
        for(let i = 0; i < 6; i++){
            if( i > 5 ) break;
            if(data["ratings"][rates][data["movies"][i]] != undefined)
                html += "<td>" + data["ratings"][rates][data["movies"][i]] + "</td>";
            else
                html +="<td>Not Rated</td>";
        }
        html += "</tr>";
    }
    html += "</table>";

    document.getElementById("dataBlock").innerHTML = html;
}

window.onload = function(){
    printData();
}

const newLocal = {
    "movies": ["Lady in the Water", "Snakes on a Plane", "Just My Luck", "Superman Returns", "You, Me and Dupree", "The Night Listener"],
    "ratings": {
        "Lisa Rose": {
            "Lady in the Water": 2.5,
            "Snakes on a Plane": 3.5,
            "Just My Luck": 3.0,
            "Superman Returns": 3.5,
            "You, Me and Dupree": 2.5,
            "The Night Listener": 3.0
        },
        "Gene Seymour": {
            "Lady in the Water": 3.0,
            "Snakes on a Plane": 3.5,
            "Just My Luck": 1.5,
            "Superman Returns": 5.0,
            "The Night Listener": 3.0,
            "You, Me and Dupree": 3.5
        },
        "Michael Phillips": {
            "Lady in the Water": 2.5,
            "Snakes on a Plane": 3.0,
            "Superman Returns": 3.5,
            "The Night Listener": 4.0
        },
        "Claudia Puig": {
            "Snakes on a Plane": 3.5,
            "Just My Luck": 3.0,
            "The Night Listener": 4.5,
            "Superman Returns": 4.0,
            "You, Me and Dupree": 2.5
        },
        "Mick LaSalle": {
            "Lady in the Water": 3.0,
            "Snakes on a Plane": 4.0,
            "Just My Luck": 2.0,
            "Superman Returns": 3.0,
            "The Night Listener": 3.0,
            "You, Me and Dupree": 2.0
        },
        "Jack Matthews": {
            "Lady in the Water": 3.0,
            "Snakes on a Plane": 4.0,
            "The Night Listener": 3.0,
            "Superman Returns": 5.0,
            "You, Me and Dupree": 3.5
        },
        "Toby": {
            "Snakes on a Plane": 4.5,
            "You, Me and Dupree": 1.0,
            "Superman Returns": 4.0
        }
    }
};

function similarity(userOne, userTwo){
    let sum = 0;
    let data = newLocal;
    for(let i = 0; i < 6; i++){
        if(data["ratings"][userOne][data["movies"][i]] == undefined )
            data["ratings"][userOne][data["movies"][i]] = 0;
        if(data["ratings"][userTwo][data["movies"][i]] == undefined )
            data["ratings"][userOne][data["movies"][i]] = 0;
        
    }
}