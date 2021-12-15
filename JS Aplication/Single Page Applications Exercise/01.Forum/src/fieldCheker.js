export function newTopicFildsCheck(title, user, text) {
    if (title == '' || user == '' || text == '') {
        if (title == '') {
            alert('Write Topic Name');
            return false;
        }
        else if (user == '') {
            alert('Write Username');
            return false;
        }
        else if (text == '') {
            alert('Write Post Text');
            return false;
        } else {
            alert('All fields must be filed up');
            return false;
        }
    }
    return true;
}

export function comentFieldCheck(text, username) {
    if (text == '' || username == '') {
        if (text == '') {
            alert('Comment field is empty');
            return false;
        }else if (username == '') {
            alert('Username field is empty');
            return false;
        }
    }
}