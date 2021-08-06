function validate() {
    document.querySelector("#submit").type = "button";
    document.querySelector("#company").addEventListener("change", (e) => {
        if (document.querySelector("#company").checked) {
            document.querySelector("#companyInfo").style.display = "block";
        } else {
            document.querySelector("#companyInfo").style.display = "none";
        }
    });

    document.querySelector("#submit").addEventListener("click", (e) => {
        let validOut = [];
        let userName = document.querySelector("#username");
        let email = document.querySelector("#email");
        let passWord = document.querySelector("#password");
        let confirmPass = document.querySelector("#confirm-password");
        let checkBox = document.querySelector("#company");
        let userTest = /^[A-Za-z0-9]{3,20}$/;
        let emailTest = /^[^@.]+@[^@]*\.[^@]*$/;
        let passTest = /^[\w]{5,15}$/;


        if (userTest.exec(userName.value) === null) {
            userName.style.borderColor = "red";
            validOut.push(false);
        } else {
            userName.style.borderColor = "";
            validOut.push(true);
        }
        if (emailTest.exec(email.value) === null) {
            email.style.borderColor = "red";
            validOut.push(false);
        } else {
            email.style.borderColor = "";
            validOut.push(true);
        }

        if (passWord.value !== confirmPass.value || passTest.exec(passWord.value) === null || passTest.exec(confirmPass.value) === null) {
            passWord.style.borderColor = "red";
            confirmPass.style.borderColor = "red";
            validOut.push(false);
        } else {
            passWord.style.borderColor = '';
            confirmPass.style.borderColor = '';
            validOut.push(true);
        }

        if (checkBox.checked) {
            let company = document.getElementById('companyNumber');
            if (company.value < 1000 || company.value > 9999) {
                company.style.borderColor = 'red';
                validOut.push(false);
            } else {
                company.style.borderColor = '';
                validOut.push(true);
            }
        }

        if (!validOut.includes(false)) {
            document.getElementById('valid').style.display = 'block';
        } else {
            document.getElementById('valid').style.display = 'none';
        }
    });
}