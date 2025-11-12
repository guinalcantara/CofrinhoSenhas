
import { useEffect, useState, useRef } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { senhaService } from "../../api/senhaService";
import { categoriaService } from "../../api/categoriaService";
import { etiquetaService } from "../../api/etiquetaService";
import type { SenhaDescriptografadaDTO } from "../../domain/senha";
import type { CategoriaDTO } from "../../domain/categoria";
import type { EtiquetaDTO } from "../../domain/etiqueta";
import { showNotify } from "../../utils/showNotify";

export function useEditPassword() {
  const navigate = useNavigate();
  const { id } = useParams();
  const isEdit = !!id;
  const hasLoadedData = useRef(false);

  const [nome, setNome] = useState("");
  const [login, setLogin] = useState("");
  const [senha, setSenha] = useState("");
  const [url, setUrl] = useState("");
  const [descricao, setDescricao] = useState("");
  const [categoriaSelecionada, setCategoriaSelecionada] = useState<number | undefined>(undefined);
  const [etiquetasSelecionadas, setEtiquetasSelecionadas] = useState<number[]>([]);
  const [categorias, setCategorias] = useState<CategoriaDTO[]>([]);
  const [etiquetas, setEtiquetas] = useState<EtiquetaDTO[]>([]);
  const [copied, setCopied] = useState(false);
  const [loading, setLoading] = useState(false);
  const [loadingInitial, setLoadingInitial] = useState(true);

  useEffect(() => {
    const fetchCategoriasEtiquetas = async () => {
      setLoadingInitial(true);
      const [cats, etis] = await Promise.all([
        categoriaService.getAll(),
        etiquetaService.getAll(),
      ]);
      setCategorias(cats ?? []);
      setEtiquetas(etis ?? []);
      setLoadingInitial(false);
    };
    fetchCategoriasEtiquetas();
  }, []);

  useEffect(() => {
    if (isEdit && id && !hasLoadedData.current && etiquetas.length > 0) {
      setLoading(true);
      senhaService.getDescriptografada(Number(id)).then((data) => {
        if (data as SenhaDescriptografadaDTO) {
          setNome(data?.titulo ?? "");
          setLogin(data?.login ?? "");
          setSenha(data?.senha ?? "");
          setUrl(data?.url ?? "");
          setDescricao(data?.descricao ?? "");
          setCategoriaSelecionada(data?.idCategoria);
          const etiquetasIds = etiquetas
            .filter((eti) => data?.etiquetas.includes(eti.nome))
            .map((eti) => eti.id);
          setEtiquetasSelecionadas(etiquetasIds);
          hasLoadedData.current = true;
        }
        setLoading(false);
      });
    }
  }, [isEdit, id, etiquetas]);

  const handleSave = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    if (isEdit && id) {
      const result = await senhaService.update(Number(id), {
        titulo: nome,
        url,
        login,
        senha,
        descricao,
        idCategoria: categoriaSelecionada,
        idEtiquetas: etiquetasSelecionadas,
      });
      if (result) {
        showNotify.success("Senha atualizada!");
        navigate("/home");
      }
    } else {
      const result = await senhaService.create({
        titulo: nome,
        url,
        login,
        senha,
        descricao,
        idUsuario: 1,
        idCategoria: categoriaSelecionada,
        idEtiquetas: etiquetasSelecionadas,
      });
      if (result) {
        showNotify.success("Senha criada!");
        navigate("/home");
      }
    }
    setLoading(false);
  };

  const handleDelete = async () => {
    if (isEdit && id && window.confirm("Confirma a exclusão da senha?")) {
      setLoading(true);
      const result = await senhaService.remove(Number(id));
      if (result !== null) {
        showNotify.success("Senha excluída!");
        navigate("/home");
      }
      setLoading(false);
    }
  };

  const handleCopy = async () => {
    try {
      await navigator.clipboard.writeText(senha);
      setCopied(true);
      setTimeout(() => setCopied(false), 1500);
    } catch {
      setCopied(false);
    }
  };

  return {
    nome,
    setNome,
    login,
    setLogin,
    senha,
    setSenha,
    url,
    setUrl,
    descricao,
    setDescricao,
    categoriaSelecionada,
    setCategoriaSelecionada,
    categorias,
    etiquetasSelecionadas,
    setEtiquetasSelecionadas,
    etiquetas,
    copied,
    handleSave,
    handleDelete,
    handleCopy,
    loading,
    loadingInitial,
    isEdit,
    markAsLoaded: () => { hasLoadedData.current = true; },
  };
}
