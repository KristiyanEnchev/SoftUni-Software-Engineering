async function loadCommits() {

    const username = document.getElementById('username').value;
    const repository = document.getElementById('repo').value;

    const url = `https://api.github.com/repos/${username}/${repository}/commits`

    const response = await fetch(url);
    const data = await response.json();

    const ulElement = document.getElementById('commits');
    ulElement.innerHTML = '';

    if (!response.ok) {
        let li = document.createElement('li');
        li.textContent = `Error: ${response.status} (Not Found)`;
        ulElement.appendChild(li);
    }

    Object.values(data).forEach(repo => {
        let liElement = document.createElement('li');
        liElement.textContent = `${repo.commit.author.name}: ${repo.commit.message}`;
        ulElement.appendChild(liElement);
    });
}