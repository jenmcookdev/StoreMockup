//Contact form with Validation

var emailRegEx = new RegExp(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/);

function validateForm(event) {
    var firstname = document.forms['mainContactForm']['firstname'].value;
    var lastname = document.forms['mainContactForm']['lastname'].value;
    var email = document.forms['mainContactForm']['email'].value;
    var subject = document.forms['mainContactForm']['subject'].value;
    var message = document.forms['mainContactForm']['message'].value;

    var firstNameValidator = document.getElementById('firstNameValidator');
    var lastNameValidator = document.getElementById('lastNameValidator');
    var emailValidator = document.getElementById('emailValidator');
    var subjectValidator = document.getElementById('subjectValidator');
    var messageValidator = document.getElementById('messageValidator');

    //validate input fields
    if (fname.length == 0 || lname.length == 0 || email.length == 0 || subject.length == 0 || message.length == 0 || !emailRegEx.test(email)) {
        if (fname.length == 0) {
            firstNameValidator.textContent = "* First name is required *";
        } else {
            firstNameValidator.textContent = "";
        }
        if (lname.length == 0) {
            lastNameValidator.textContent = "* Last name is required *";
        } else {
            lastNameValidator.textContent = "";
        }
        if (email.length == 0) {
            emailValidator.textContent = "* Email is required *";
        } else {
            emailValidator.textContent = "";
        }
        if (!emailRegEx.test(email) && email.length > 0) {
            emailValidator.textContent = "* Must be a valid email address *";
        }
        if (subject.length == 0) {
            subjectValidator.textContent = "* Subject field is required *";
        } else {
            subjectValidator.textContent = "";
        }
        if (message.length == 0) {
            messageValidator.textContent = "* Message is required *";
        } else {
            messageValidator.textContent = "";
        }
    }//end of input validation
    else { //Submit successfully if validation passes
        //remove validator text
        firstNameValidator.textContent = "";
        lastNameValidator.textContent = "";
        emailValidator.textContent = "";
        subjectValidator.textContent == "";
        messageValidator.textContent = "";

        //gather values of the fields
        var fnameValue = $("#fname").val();
        var lnameValue = $("#lname").val();
        var emailValue = $("#email").val();
        var subjectValue = $("#subject").val();
        var messageValue = $("#message").val();

        //popup dialog box
        $("#contactDialog").dialog({
            open: function () {
                var markup = "Thank you!" + "<br/>Message Details: " + "<br/>Sent by: " + fnameValue + lnameValue + " " + "(" + emailValue + ") " + " " + "<br/>Subject: " + subjectValue + "<br/>Comment: " + messageValue;
                $(this).html(markup);
            },//end open: function
            modal: true,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }//end ok:
            }//end buttons:
        });//end contactDialog
    }//end else

    event.preventDefault();
}//end function validateForm

// add color to text field for user, should revert once field exited
$(document).ready(function () {
    $('input:text').focus(
    function () {
        $(this).css({ 'background-color': '#F3DEFF' });
    });

    $('input:text').blur(
        function () {
            $(this).css({ 'background-color': '#DEECFF' });
        });

    $('#commentArea').focus(
    function () {
        $(this).css({ 'background-color': '#F3DEFF' });
    });

    $('#commentArea').blur(
       function () {
           $(this).css({ 'background-color': '#DEECFF' });
       });
});//end document

//End of Contact form JS

// Accordion on FAQ.html
$(".accordion").accordion({
    heightStyle: "content"
});

var heightStyle = $(".accordion").accordion("option", "heightStyle");
$(".accordion").accordion("option", "heightStyle", "content");