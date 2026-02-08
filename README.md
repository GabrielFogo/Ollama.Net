### Como rodar o ollama com docker
```
 docker run -d -v ollama:/root/.ollama -p 11434:11434 --name ollama-container ollama/ollama
```

### Baixar o modelo
```
 docker exec ollama-container ollama pull llama3
```

