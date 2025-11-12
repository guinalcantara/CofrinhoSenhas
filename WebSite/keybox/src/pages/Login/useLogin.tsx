import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { showNotify } from "../../utils/showNotify";
import { isNullOrEmpty } from "../../utils/text";
import { usuarioService } from "../../api/usuarioService";
import type { LoginDTO } from "../../domain/usuario";

export function useLogin() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const validations = [
      { condition: isNullOrEmpty(username), message: "Informe o e-mail!" },
      { condition: isNullOrEmpty(password), message: "Informe a senha!" },
    ];

    for (const v of validations) {
      if (v.condition) {
        showNotify.warning(v.message);
        return;
      }
    }

    setLoading(true);
    try {
      const loginData: LoginDTO = { email: username, senha: password };
      const user = await usuarioService.login(loginData);
      if (user) {
        navigate("/home");
      }
    } finally {
      setLoading(false);
    }
  };

  return {
    username,
    setUsername,
    password,
    setPassword,
    handleSubmit,
    loading,
  };
}