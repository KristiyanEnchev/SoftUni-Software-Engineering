function loadRepos() {
	const username = document.getElementById('username').value;

	const url = `https://api.github.com/users/${username}/repos`;

	fetch(url)
		.then(res => res.json())
		.then((data) => {
			const ulElement = document.getElementById('repos');
			ulElement.innerHTML = '';
			data.forEach(repo => {
				let liElement = document.createElement('li');
				let anchor = document.createElement('a');
				anchor.setAttribute('href', repo.clone_url);
				liElement.appendChild(anchor);
				anchor.textContent = repo.full_name;
				ulElement.appendChild(liElement);
			});
		})
		.catch(error => {
			console.log("Promise rejected");
			console.log(error);
		});
}