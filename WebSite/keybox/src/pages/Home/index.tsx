import List from "../../components/GenericComponents/List";
import Button from "../../components/GenericComponents/Button";
import { useHome } from "./useHome";
import Input from "../../components/GenericComponents/Input";
import Select from "../../components/GenericComponents/Select";
import { useTheme } from "../../hooks/useTheme";
import LabelType from "../../components/GenericComponents/LabelType";
import AccountIcon from "../../components/GenericComponents/AccountIcon";
import { PageContainer } from "../../components/Layout";
import SkeletonLoader from "../../components/GenericComponents/SkeletonLoader";

function Home() {
    const {
        senhas,
        etiquetas,
        categorias,
        categoriaSelecionada,
        setCategoriaSelecionada,
        etiquetaSelecionada,
        setEtiquetaSelecionada,
        handleEdit,
        handleDelete,
        loading,
        filterText,
        setFilterText,
    } = useHome();
    const { theme } = useTheme();
    return (
        <PageContainer
            title="Home"
            breadcrumbs={[{ title: "Home" }]}
            actions={
                <Button
                    label="Nova Senha"
                    type="button"
                    style={{ background: theme.info, color: "#fff" }}
                    onClick={() => handleEdit(0)}
                />
            }
        >
            <div style={{ marginBottom: "1rem", display: "flex", gap: "1rem" }}>
                <Select
                    name="categoria"
                    value={String(categoriaSelecionada)}
                    options={
                        categorias.map(cat => ({ value: String(cat.id), label: cat.nome }))
                    }
                    onChange={val => setCategoriaSelecionada(Number(val))}
                    placeholder="Selecione a categoria"
                />
                <Select
                    name="etiqueta"
                    value={String(etiquetaSelecionada)}
                    options={etiquetas.map(eti => ({ value: String(eti.id), label: eti.nome }))}
                    onChange={val => setEtiquetaSelecionada(Number(val))}
                    placeholder="Selecione a etiqueta"
                />
                <Input
                    name="filter"
                    placeholder="Pesquisar"
                    type="text"
                    value={filterText}
                    onChange={setFilterText}
                />
            </div>
            <List>
                {loading && <SkeletonLoader type="list" count={5} />}
                {!loading &&
                    senhas.map((senha) => (
                        <div
                            key={senha.id}
                            style={{
                                display: "flex",
                                alignItems: "center",
                                justifyContent: "space-between",
                                borderBottom: "1px solid #eee",
                                gap: "1rem",
                            }}
                        >
                            <div style={{ flex: 1, display: "flex", alignItems: "center", gap: "1rem" }}>
                                <AccountIcon size={40} />
                                <div style={{ flex: 1 }}>
                                    <strong>{senha.titulo}</strong> <br />
                                    <span>{senha.login}</span>
                                    <div style={{ display: "flex", gap: "0.5rem", justifySelf: "start", paddingBottom: "0.5rem" }}>
                                        {senha.nomeCategoria && (
                                            <LabelType color={theme.secondary} values={[senha.nomeCategoria]} />
                                        )}
                                        {senha.etiquetas && senha.etiquetas.length > 0 && (
                                            <LabelType color={theme.primary} values={senha.etiquetas} />
                                        )}
                                    </div>
                                </div>
                            </div>
                            <div style={{ display: "flex", gap: "0.5rem" }}>
                                <Button
                                    label="Editar"
                                    type="button"
                                    style={{ background: theme.secondary, color: "#fff" }}
                                    onClick={() => handleEdit(senha.id)}
                                />
                                <Button
                                    label="Excluir"
                                    type="button"
                                    style={{ background: theme.danger, color: "#fff" }}
                                    onClick={() => handleDelete(senha.id)}
                                />
                            </div>
                        </div>
                    ))}
            </List>
        </PageContainer>
    );
}

export default Home;
