function OncilckLogin() {
    $(document).ready(function () {

        const loginUsername = document.querySelector("#loginusername");
        const loginEmail = document.querySelector("#loginemail");
        const clearUsername = document.getElementById('username');
        const clearPasswordEmail = document.getElementById('passwordemail');
        const clearEmail = document.getElementById('email');
        const clearPasswordUsername = document.getElementById('password');

        document.querySelector("#linkloginemail").addEventListener("click", e => {
            e.preventDefault();
            loginUsername.classList.add("form--hidden");
            loginEmail.classList.remove("form--hidden");
            clearEmail.value = '';
            clearPasswordEmail.value = '';
            $(".eye-event-email").hide();

        });

        document.querySelector("#linkloginusername").addEventListener("click", e => {
            e.preventDefault();
            loginUsername.classList.remove("form--hidden");
            loginEmail.classList.add("form--hidden");
            clearUsername.value = '';
            clearPasswordUsername.value = '';
            $(".eye-event").hide();

        });


    });
}