//declaring the RegEx outside function to use within function for email checking
var emailRegEx = new RegExp(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/);//has to have beginning & ending /'s

function validateForm(event) {
    //with custom JS we will require each field.
    var name = document.forms['main-contact-form']['name'].value;  //says to search the form for the name 'name' inside the form id of main-contact-form
    var email = document.forms['main-contact-form']['email'].value;
    var subject = document.forms['main-contact-form']['subject'].value;
    var message = document.forms['main-contact-form']['message'].value;

    //Get error message <span>
    var firstNameVal = document.getElementById('firstNameVal');
    var lastNameVal = document.getElementById('lastNameVal');
    var emailVal = document.getElementById('emailVal');
    var subjectVal = document.getElementById('subjectVal');
    var messageVal = document.getElementById('messageVal');

    //Test all of our conditions including checking for a valid email address

    if (name.length == 0 || email.length == 0 || subject.length == 0 || message.length == 0 || !emailRegEx.test(email)) {

        //Error messages under each required field.
        if (firstName.length == 0) {
            firstNameVal.textContent = "* Name is required.";
        } else {
            firstNameVal.textContent = "";
        }//end else

        if (lastName.length == 0) {
            lastNameVal.textContent = "* Name is required.";
        } else {
            lastNameVal.textContent = "";
        }//end else


        if (email.length == 0) {
            emailVal.textContent = "* email is required.";
        } else {
            emailVal.textContent = "";
        }//end else

        //error message if email is not valid
        if (!emailRegEx.test(email) && email.length > 0) {
            emailVal.textContent = "* Must be a valid email address *";
        }
        //if (emailRegEx.test(email) && email.lengh > 0) {
        //    emailVal.textContent - "";
        //}

        if (subject.length == 0) {
            subjectVal.textContent = "* Subject is required.";
        } else {
            subjectVal.textContent = "";
        }//end else

        if (message.length == 0) {
            messageVal.textContent = "* Message is required.";
        } else {
            messageVal.textContent = "";
        }//end else

        event.preventDefault(); //prevent default action of triggering  refresh to allow for error messages to display

    }//end if


};//end function()
