# 🎬 API de Filmes - ASP.NET Core Minimal API

Projeto desenvolvido para a disciplina de Desenvolvimento Back-End utilizando:

- C#
- .NET
- ASP.NET Core Minimal API
- Entity Framework Core
- SQLite

---

# 📚 Sobre o Projeto

Esta aplicação é uma API REST simples para gerenciamento de filmes.

O projeto foi desenvolvido utilizando Minimal API, sem Controllers, sem arquitetura em camadas e sem Repository Pattern, mantendo uma estrutura simples e objetiva.

A API permite:

- Cadastrar filmes
- Listar filmes
- Buscar filme por ID
- Atualizar filmes
- Remover filmes
- Buscar filmes por título
- Listar filmes em cartaz
- Contar quantidade de registros
- Validar dados enviados pelo usuário

---

# 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Minimal API
- Entity Framework Core
- SQLite
- Bruno (testes da API)

---

# 📁 Estrutura do Projeto

```txt
ApiFilmes/
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   └── Filme.cs
│
├── bruno/
│
├── Program.cs
├── appsettings.json
├── filmes.db
└── README.md
```

---

# ⚙️ Como Executar o Projeto

## 1. Clonar o repositório

```bash
git clone URL_DO_REPOSITORIO
```

---

## 2. Entrar na pasta

```bash
cd ApiFilmes
```

---

## 3. Restaurar dependências

```bash
dotnet restore
```

---

## 4. Executar a aplicação

```bash
dotnet run
```

---

# 🌐 Endpoints da API

| Método | Endpoint | Descrição |
|---|---|---|
| GET | / | Mensagem inicial |
| GET | /status | Status da API |
| GET | /filmes | Listar filmes |
| GET | /filmes/{id} | Buscar filme por ID |
| POST | /filmes | Cadastrar filme |
| PUT | /filmes/{id} | Atualizar filme |
| DELETE | /filmes/{id} | Remover filme |
| GET | /filmes/emcartaz | Listar filmes em cartaz |
| GET | /filmes/quantidade | Quantidade de filmes |
| GET | /filmes/busca/{titulo} | Buscar por título |

---

# 🧪 Exemplo de JSON

## POST /filmes

```json
{
  "titulo": "Interestelar",
  "diretor": "Christopher Nolan",
  "duracaoMinutos": 169,
  "emCartaz": true,
  "dataLancamento": "2014-11-07"
}
```

---

# ✅ Funcionalidades Implementadas

- CRUD completo
- SQLite integrado
- Entity Framework Core
- Async/Await
- Minimal API
- Validações
- Retorno 400 BadRequest
- Filtros
- Busca por título
- Contagem de registros

---

# 👨‍💻 Autor

Projeto desenvolvido por Ulisses Fernandes.

