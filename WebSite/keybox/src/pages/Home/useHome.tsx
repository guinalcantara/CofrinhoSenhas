import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { senhaService } from "../../api/senhaService";
import { categoriaService } from "../../api/categoriaService";
import { etiquetaService } from "../../api/etiquetaService";
import type { SenhaDTO } from "../../domain/senha";
import type { CategoriaDTO } from "../../domain/categoria";
import type { EtiquetaDTO } from "../../domain/etiqueta";
import { showNotify } from "../../utils/showNotify";

export function useHome() {
  const [senhas, setSenhas] = useState<SenhaDTO[]>([]);
  const [categorias, setCategorias] = useState<CategoriaDTO[]>([]);
  const [etiquetas, setEtiquetas] = useState<EtiquetaDTO[]>([]);
  const [categoriaSelecionada, setCategoriaSelecionada] = useState(0);
  const [etiquetaSelecionada, setEtiquetaSelecionada] = useState(0);
  const [loading, setLoading] = useState(false);
  const [filterText, setFilterText] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    fetchInitial();
  }, []);

  useEffect(() => {
    fetchSenhas();
  }, [categoriaSelecionada, etiquetaSelecionada, filterText]);

  const handleEdit = (id: number) => {
    navigate(`/editar/${id}`);
  };

  const fetchInitial = async () => {
    setLoading(true);
    const [senhasData, categoriasData, etiquetasData] = await Promise.all([
      senhaService.getAll(),
      categoriaService.getAll(),
      etiquetaService.getAll(),
    ]);
    setSenhas(senhasData ?? []);
    setCategorias(categoriasData ?? []);
    setEtiquetas(etiquetasData ?? []);
    setLoading(false);
  };

  const fetchSenhas = async () => {
    setLoading(true);

    const result = categoriaSelecionada
      ? await senhaService.getByCategoria(categoriaSelecionada)
      : await senhaService.getAll();

    let filtrar = result ?? [];

    if (etiquetaSelecionada) {
      const etiquetaNome = etiquetas.find(e => e.id === etiquetaSelecionada)?.nome;
      if (etiquetaNome) {
        filtrar = filtrar.filter(s => s.etiquetas.includes(etiquetaNome));
      }
    }

    if (filterText.trim()) {
      const texto = filterText.toLowerCase();
      filtrar = filtrar.filter(
        s =>
          s.titulo.toLowerCase().includes(texto) ||
          s.login.toLowerCase().includes(texto)
      );
    }

    setSenhas(filtrar);
    setLoading(false);
  };

  const handleDelete = async (id: number) => {
    if (window.confirm("Confirma a exclusão da senha?")) {
      const result = await senhaService.remove(id);
      if (result !== null) {
        showNotify.success("Senha excluída com sucesso!");
        setSenhas((prev) => prev.filter((s) => s.id !== id));
      }
    }
  };

  return {
    senhas,
    categorias,
    etiquetas,
    categoriaSelecionada,
    setCategoriaSelecionada,
    etiquetaSelecionada,
    setEtiquetaSelecionada,
    handleEdit,
    handleDelete,
    loading,
    filterText,
    setFilterText,
  };
}
