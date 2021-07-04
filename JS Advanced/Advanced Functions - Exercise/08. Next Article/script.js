function getArticleGenerator(articles) {
    return function showNext() {
        if (articles.length > 0) {
            let articlesArray = articles;
            let article = document.createElement('article');
            article.innerText = articlesArray.shift();
            if (article.innerText !== 'undefined') {
                let content = document.getElementById('content');
                content.appendChild(article);
            }
        }
    }
}