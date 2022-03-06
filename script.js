
let task;
let mellan = 0;
let uncomplete = 0;
let i = 0;

//loading the page
let ul = document.querySelector('.task-box');
//ul.style.display ='none;'
let button = document.querySelector(".buttons");
button.style.display = 'none';
let clear = document.querySelector(".clearall");
clear.style.display = 'none';
let inputcheck = document.querySelector('.icon-chevron-down');
inputcheck.style.display = 'none';
///take user input to add to the ToDo list
let input = document.querySelector('.task-input');
let inputText = input.querySelector('.input_text');
input.addEventListener("keypress", function (event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        add(inputText.value);
        inputText.value = "";
    }
});

function add(text) {

    if (!text) { return; }
    let ul = document.querySelector('.task-box');
    let template = document.querySelector("#todo-template");
    let li = template.content.firstElementChild.cloneNode(true);
    li.querySelector('.todo-text').textContent = text;
    let doneToggle = li.querySelector('.toggle');
    let removeButton = li.querySelector('.remove-button');
    removeButton.onclick = () => {
        if (doneToggle.checked == true) {
            li.remove();
        }
        else if (doneToggle.checked == false) {
            uncomplete--;
            li.remove();
        }
        document.getElementById("uncompleted").innerHTML = uncomplete;
        if (uncomplete == 0) button.style.display = 'none';
    };
    doneToggle.onclick = () => {
        if (doneToggle.checked == true) {
            doneToggle.checked == false;
            uncomplete = uncomplete - 1;
            clear.style.display = 'flex';
        }
        else if (doneToggle.checked == false) {
            doneToggle.checked == true;
            uncomplete++;
            clear.style.display = 'none';
        }
        document.getElementById("uncompleted").innerHTML = uncomplete;
        clear.style.display = 'block';
    }

    ul.append(li);
    uncomplete++;
    inputText.value = "";
    button.style.display = 'block';
    clear.style.display = 'none';
    inputcheck.style.display = 'block';
    document.getElementById("uncompleted").innerHTML = uncomplete;
    let liItems = document.querySelector('.task-box').querySelectorAll('li');

    for (const li of liItems) {
        let toggle = li.querySelector('.toggle');
        if (toggle.checked == true) clear.style.display = 'flex';
    }
}



//show active tasks
let activ = document.querySelector(".active");
activ.onclick = () => {
    activeonly();

}

function activeonly() {
    let liItems = document.querySelector('.task-box').querySelectorAll('li');

    for (const li of liItems) {
        let toggle = li.querySelector('.toggle');
        if (toggle.checked == true) { li.style.display = 'none' }
        else li.style.display = 'flex';
    }
}
//show completed tasks
let completee = document.querySelector(".completed");
completee.onclick = () => {
    completeonly();
}
function completeonly() {
    let liItems = document.querySelector('.task-box').querySelectorAll('li');

    for (const li of liItems) {
        let toggle = li.querySelector('.toggle');
        if (toggle.checked != true) { li.style.display = 'none' }
        else li.style.display = 'flex';
    }

}

//show all tasks

let show = document.querySelector(".showall");
show.onclick = () => {
    showall();
}
function showall() {
    let liItems = document.querySelector('.task-box').querySelectorAll('li');
    for (const li of liItems) {
        li.style.display = 'flex';
    }
}

//delete all tasks
let deletee = document.querySelector(".clearall");
deletee.onclick = () => {
    deletecompleted();
}

function deletecompleted() {
    let liItems = document.querySelector('.task-box').querySelectorAll('li');
    for (const li of liItems) {
        if (li.querySelector('.toggle').checked == true) {
            li.remove();
            // uncomplete--;
        }
    }
    if (document.querySelector("#uncompleted").textContent != 0) {
        button.style.display = 'block';
        clear.style.display = 'none';
        inputcheck.style.display = 'block';
    }

    else if (document.querySelector("#uncompleted").textContent == 0) {
        uncomplete = 0;
        button.style.display = 'none';
        inputcheck.style.display = 'none';
    }
}


let allcheck = document.querySelector(".icon-chevron-down");
allcheck.onclick = () => {

    document.getElementById("uncompleted").innerHTML = 0;
    clear.style.display = 'block';
    if (allcheck.checked == true) {
        toggleAll(); mellan = uncomplete; uncomplete = 0;
        ////  allcheck.checked == false;
    }
    else
        untoggleall();
    //  allcheck.checked == true;

}



function untoggleall() {
    let liItems = document.querySelector('.task-box').querySelectorAll('li');

    for (const li of liItems) {
        let toggle = li.querySelector('.toggle');
        toggle.checked = false; i++
    }
    document.getElementById("uncompleted").innerHTML = i;
    uncomplete = i;
    i = 0;

    clear.style.display = 'none'
}



function toggleAll() {

    let liItems = document.querySelector('.task-box').querySelectorAll('li');

    for (const li of liItems) {
        let toggle = li.querySelector('.toggle');
        if (toggle.checked != true)
            toggle.checked = true;


    }

    document.getElementById("uncompleted").innerHTML == 0;
}





