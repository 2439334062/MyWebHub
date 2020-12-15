document.querySelector('.chat[data-chat=person1]').classList.add('active-chat');
document.querySelector('.person[data-chat=person1]').classList.add('active');
var uName;
var chatType;
var dataId
//var friends = {
//  list: document.querySelector('ul.people'),
//  all: document.querySelectorAll('.left .person'),
//  name: '' },

//chat = {
//    container: document.querySelector('.container .right'),
//    current: null,
//    person: null,
//    id: null,
//    name: document.querySelector('.container .right .top .name')
//    };


//friends.all.forEach(function (f) {
//  f.addEventListener('mousedown', function () {
//    f.classList.contains('active') || setAciveChat(f);
//  });
//});

//function setAciveChat(f) {
//    friends.list.querySelector('.active').classList.remove('active');
//    f.classList.add('active');
//    chat.current = chat.container.querySelector('.active-chat');
//    chat.person = f.getAttribute('data-chat');
//    chat.current.classList.remove('active-chat');
//    chat.container.querySelector('[data-chat="' + chat.person + '"]').classList.add('active-chat');
//    friends.name = f.querySelector('.name').innerText;
//    chatType = f.querySelector('.preview').innerText;
//    uName = friends.name;
//    dataId = uName;
//    chat.name.innerHTML = friends.name;
//}


function login() {
    var rotate = document.querySelector(".rotate");
    var btn = document.getElementById("btn");
    var btn2 = document.getElementById("btn2");
    btn.onclick = function () {
        rotate.classList.add("change");
    }
    btn2.onclick = function () {
        rotate.classList.remove("change");
    }
}
login();
function pop() {
    var bg = document.querySelector(".bg");
    var loginCard = document.querySelector(".login-card");
    var close = document.querySelector(".card-front .top_nav")
    var close2 = document.querySelector(".card-back .top_nav")
    bg.onclick = function () {
        // classLlist属性，用于在元素中添加，移除及切换 CSS 类
        loginCard.classList.remove("card-active");
        loginCard.classList.add("card-active2");
        setTimeout(function () {
            bg.classList.remove("active")
        }, 200)
    }
    loginCard.onclick = function (e) {
        if (e.target == close || e.target == close2) return;
        e.stopPropagation();
    }

    var loginBtn = document.querySelector(".login-btn");
    loginBtn.onclick = function () {
        loginCard.classList.remove("card-active2");
        loginCard.classList.add("card-active");
        bg.classList.add("active");
    }
}
pop();