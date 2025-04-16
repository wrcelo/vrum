# VrumApp API

API desenvolvida em .NET 8 para gerenciamento de motos.

## 🚀 Tecnologias Utilizadas

- ASP.NET 8.0
- Docker + Docker Compose
- PostgreSQL
- RabbitMQ
- MinIO (para armazenamento de imagens)
- Autenticação JWT
- Role-based Authorization

---

## 🛠 Como rodar a aplicação

### Usando Docker Compose (recomendado)

1. Certifique-se de que você tem o Docker e Docker Compose instalados.
2. No terminal, execute:

```bash
docker-compose up
```

Isso irá subir toda a infraestrutura da aplicação, incluindo banco de dados, mensageria, MinIO, etc.

### Usando o Visual Studio 2022

1. Abra a solução no Visual Studio 2022.
2. No menu superior, selecione o projeto de inicialização (startup project) como **docker-compose**.
3. Clique no botão **verde (Start)** para iniciar a aplicação.
4. Para utilizar em modo Debug, certifique-se de estar com o Docker Desktop aberto.

---

## 📚 Documentação da API

A documentação interativa (Swagger) está disponível após subir a aplicação.  
Acesse pelo navegador: http://localhost:5000/swagger

Lá você pode testar os endpoints, visualizar contratos e realizar requisições autenticadas com JWT.

---

## 🔐 Acesso inicial

Ao iniciar a aplicação, um usuário padrão com permissão de Admin é criado automaticamente com as seguintes credenciais:

- **Email:** `admin@vrum.com`  
- **Senha:** `vrum123`

Você pode utilizá-las para realizar login no endpoint:

```
POST /api/auth/login
```

### Exemplo de payload:

```json
{
  "email": "admin@vrum.com",
  "password": "vrum123"
}
```

A resposta conterá um **token JWT**, que poderá ser utilizado no header `Authorization` das próximas requisições:

```
Authorization: Bearer <seu-token-aqui>
```

---

## 🔒 Controle de Acesso

Somente usuários com a **role `Admin`** possuem permissão para acessar os endpoints de gerenciamento de motos (`/api/motorcycles`).

---

## 📂 Estrutura do Projeto

```
src/
├── Wrcelo.VrumApp.API/            # Projeto principal da API
├── Wrcelo.VrumApp.Domain/         # Entidades de domínio e regras de negócio
├── Wrcelo.VrumApp.Application/    # Camada de aplicação (DTOs, serviços)
├── Wrcelo.VrumApp.Infrastructure/ # Acesso a dados, RabbitMQ, MinIO etc.
├── Wrcelo.VrumApp.Core/           # Camada core (compartilhada entre camadas)
```

---

## 👤 Criação de Entregadores e Usuários

Ao criar um entregador utilizando o endpoint:

```
POST /api/delivery-drivers
```

Um usuário é criado automaticamente com as credenciais (email e senha) fornecidas no payload.

Essas credenciais podem ser utilizadas para realizar login normalmente através do endpoint:

```
POST /api/auth/login
```

Dessa forma, entregadores podem acessar funcionalidades específicas do sistema com seu próprio login.

---

## 📌 Observações

- A aplicação depende de serviços externos (RabbitMQ, Banco de Dados, MinIO), então o uso do Docker é altamente recomendado.
- Certifique-se de que as portas utilizadas pelos containers não estejam ocupadas no seu sistema.
- É possível configurar variáveis de ambiente e strings de conexão no arquivo `appsettings.json` ou através de secrets no Docker.
