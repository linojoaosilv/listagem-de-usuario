import { useEffect, useState } from "react";
import CardUsuario from "../../components/CardUsuarios/CardUsuarios";
import axios from "axios";
import './ListaDeUsuarios.css'

function ListaDeUsuarios() {
  const [usuarios, setUsuarios] = useState([]);

  useEffect(() => {
    BuscarUsuarios();
  }, []);

  async function BuscarUsuarios() {
    const response = await axios.get(
      "https://localhost:44387/api/Usuarios/listar"
    );

    if (response.status != 200) {
      alert("Erro ao listar usuários");
      return;
    }
    console.log(response);
    setUsuarios(response.data);
  }

  return (
    <div className="div_Lista">
      {usuarios.map((usuario) => (
        <CardUsuario usuario={usuario}></CardUsuario>
      ))}
    </div>
  );
}

export default ListaDeUsuarios;