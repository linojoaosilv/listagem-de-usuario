import React, { useState } from "react";
import axios from "axios";
import "./CadastroUsuario.css"
 
export default function CadastroDeUsuarios() {

  const [nome, setNome] = useState();
  const [telefone, setTelefone] = useState();
  const [email, setEmail] = useState();
 
  async function handleSubmit(e) {
    e.preventDefault();


    //codigo que verifica se o campo do input esta vazio
    if (!nome) {
        alert("Nome obrigatorio");
        return;
    }
    if (!telefone) {
        alert("Nome obrigatorio");
        return;
    }
    if(!email){
        alert("Nome obrigatorio");
        return;
    }
    
    const body = { nome, telefone, email }; // criando o body para a API receber os dados do usuario cadastrado
    const response = await axios.post(
      "https://localhost:44387/api/usuarios/cadastrar",
      body
    ); // conexão com a API, com a url da função "cadastrar"
 
    if (response.status == 200) {
      alert("Cadastrado com sucesso");
      window.location.reload();
      return;
    }
    alert("Deu ruim"); // verifica se tudo deu certo (retornou 200, o ok no caso), caso não esteja nos conformes, ele retorna a mensagem "deu ruim" ou oq vc escreverKKK
  }
 
  return (
    <div className="div_geral">
        <h1>Bote seu nome</h1>
        <form onSubmit={handleSubmit} // definindo o tipo de ação que o formulario ira realizar, e qual função ela ira usar (a q vc criou no caso)
>
        <label>
          Nome:
          <input
            type="text"
            value={nome}
            onChange={(e) => setNome(e.target.value)} // o ".target.value" pega o valor digitado pelo usuario e adiciona ao state que vc criou antes
          />
        </label>
        <label>
          Email:
          <input
            type="text"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </label>
        <label>
          Telefone:
          <input
            type="text"
            value={telefone}
            onChange={(e) => setTelefone(e.target.value)}
          />
        </label>
        <input type="submit" value="Cadastrar"></input>
      </form>
    </div>
  );
}