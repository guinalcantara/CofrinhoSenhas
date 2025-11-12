import Input from "../../components/GenericComponents/Input";
import Button from "../../components/GenericComponents/Button";
import Select from "../../components/GenericComponents/Select";
import MultiSelect from "../../components/GenericComponents/MultiSelect";
import { useEditPassword } from "./useEditPassword";
import { useTheme } from "../../hooks/useTheme";
import { useNavigate, useLocation } from "react-router-dom";
import { useEffect } from "react";
import { PageContainer } from "../../components/Layout";
import * as S from "./styles";
import SkeletonLoader from "../../components/GenericComponents/SkeletonLoader";

function EditPassword() {
    const {
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
        markAsLoaded,
    } = useEditPassword();
    const { theme } = useTheme();
    const navigate = useNavigate();
    const location = useLocation();

    useEffect(() => {
        if (location.state?.generatedPassword) {
            markAsLoaded();
            setSenha(location.state.generatedPassword);

            if (location.state?.formData) {
                const formData = location.state.formData;
                setNome(formData.nome);
                setLogin(formData.login);
                setUrl(formData.url);
                setDescricao(formData.descricao);
                setCategoriaSelecionada(formData.categoriaSelecionada);
                setEtiquetasSelecionadas(formData.etiquetasSelecionadas);

                if (formData.id && !isEdit) {
                    navigate(`/editar/${formData.id}`, { replace: true, state: location.state });
                }
            }
        }
    }, [location.state, setSenha, setNome, setLogin, setUrl, setDescricao, setCategoriaSelecionada, setEtiquetasSelecionadas, isEdit, navigate, markAsLoaded]); return (
        <PageContainer
            title={isEdit ? "Editar Senha" : "Nova Senha"}
            breadcrumbs={[
                { title: "Home", path: "/home" },
                { title: isEdit ? "Editar Senha" : "Nova Senha" }
            ]}
            actions={
                <Button
                    style={{ background: theme.info, color: "#fff" }}
                    label="Voltar"
                    type="button"
                    onClick={() => navigate("/home")}
                />
            }
        >
            {loadingInitial ? (
                <SkeletonLoader type="form" count={6} />
            ) : (
                <S.Form onSubmit={handleSave}>
                    <Input
                        showPlaceholderLabel={true}
                        name="nome"
                        placeholder="Título/Nome"
                        type="text"
                        value={nome}
                        onChange={setNome}
                    />
                    <Input
                        showPlaceholderLabel={true}
                        name="login"
                        placeholder="Usuário/Login"
                        type="text"
                        value={login}
                        onChange={setLogin}
                    />
                    <S.Row>
                        <Input
                            showPlaceholderLabel={true}
                            name="senha"
                            placeholder="Senha"
                            type="password"
                            value={senha}
                            onChange={setSenha}
                        />
                        <Button
                            type="button"
                            label={copied ? "Copiado!" : "Copiar"}
                            style={{ background: theme.secondary, color: "#fff", margin: "1.6rem 0 0 0", padding: "0 1rem" }}
                            onClick={handleCopy}
                        />
                        <Button
                            type="button"
                            label="Gerar"
                            style={{ background: theme.info, color: "#fff", margin: "1.6rem 0 0 0", padding: "0 1rem" }}
                            onClick={() => navigate("/criar-senha", {
                                state: {
                                    formData: {
                                        id: isEdit ? Number(location.pathname.split("/").pop()) : undefined,
                                        nome,
                                        login,
                                        url,
                                        descricao,
                                        categoriaSelecionada,
                                        etiquetasSelecionadas
                                    }
                                }
                            })}
                        />
                    </S.Row>
                    <Input
                        showPlaceholderLabel={true}
                        name="url"
                        placeholder="URL"
                        type="text"
                        value={url}
                        onChange={setUrl}
                    />
                    <Input
                        showPlaceholderLabel={true}
                        name="descricao"
                        placeholder="Descrição"
                        type="text"
                        value={descricao}
                        onChange={setDescricao}
                    />
                    <S.Row>
                        <Select
                            name="categoria"
                            value={categoriaSelecionada ? String(categoriaSelecionada) : ""}
                            options={[
                                { value: "", label: "Selecione a categoria" },
                                ...categorias.map(cat => ({ value: String(cat.id), label: cat.nome }))
                            ]}
                            onChange={val => setCategoriaSelecionada(val === "" ? undefined : Number(val))}
                            placeholder="Categoria"
                        />
                        <MultiSelect
                            name="etiquetas"
                            value={etiquetasSelecionadas}
                            options={etiquetas.map(eti => ({ value: eti.id, label: eti.nome }))}
                            onChange={vals => setEtiquetasSelecionadas(vals.map(Number))}
                            placeholder="Etiquetas"
                        />
                    </S.Row>
                    <S.Actions>
                        {isEdit && (
                            <Button
                                style={{ width: "100%", background: theme.danger }}
                                label="Deletar"
                                type="button"
                                onClick={handleDelete}
                            />
                        )}
                        <Button
                            style={{ width: "100%", background: theme.success }}
                            label={loading ? "Salvando..." : isEdit ? "Salvar" : "Salvar"}
                            type="submit"
                        />
                    </S.Actions>
                </S.Form>
            )}
        </PageContainer>
    );
}

export default EditPassword;
