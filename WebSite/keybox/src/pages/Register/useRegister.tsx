import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { showNotify } from "../../utils/showNotify";
import { isNullOrEmpty } from "../../utils/text";
import { usuarioService } from "../../api/usuarioService";
import type { CriarUsuarioDTO } from "../../domain/usuario";

export function useRegister() {
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (isNullOrEmpty(nome)) {
      showNotify.warning("Informe o nome!");
      return;
    }
    if (isNullOrEmpty(email)) {
      showNotify.warning("Informe o e-mail!");
      return;
    }
    if (isNullOrEmpty(senha)) {
      showNotify.warning("Informe a senha!");
      return;
    }
    setLoading(true);
    try {
      const data: CriarUsuarioDTO = { nome, email, senha };
      const user = await usuarioService.create(data);
      if (user) {
        showNotify.success("Usuário cadastrado com sucesso!");
        navigate("/login");
      }
    } finally {
      setLoading(false);
    }
  };

  return {
    nome,
    setNome,
    email,
    setEmail,
    senha,
    setSenha,
    handleSubmit,
    loading,
  };
}
