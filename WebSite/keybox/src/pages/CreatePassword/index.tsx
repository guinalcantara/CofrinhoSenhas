import { useState } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import Button from "../../components/GenericComponents/Button";
import Checkbox from "../../components/GenericComponents/Checkbox";
import { PageContainer } from "../../components/Layout";
import * as S from "./styles";

const UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
const LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
const NUMBERS = "0123456789";
const SYMBOLS = "!@#$%^&*()-_=+[]{}|;:,.<>?";

interface EditPasswordFormData {
    id?: number;
    nome: string;
    login: string;
    url: string;
    descricao: string;
    categoriaSelecionada?: number;
    etiquetasSelecionadas: number[];
}

const CreatePassword = () => {
    const [uppercase, setUppercase] = useState(true);
    const [lowercase, setLowercase] = useState(true);
    const [numbers, setNumbers] = useState(true);
    const [symbols, setSymbols] = useState(true);
    const [length, setLength] = useState(15);
    const [password, setPassword] = useState("");
    const navigate = useNavigate();
    const location = useLocation();

    const formData = location.state?.formData as EditPasswordFormData | undefined;

    const generatePassword = () => {
        let chars = "";
        if (uppercase) chars += UPPERCASE;
        if (lowercase) chars += LOWERCASE;
        if (numbers) chars += NUMBERS;
        if (symbols) chars += SYMBOLS;
        if (!chars) return setPassword("");
        let pass = "";
        for (let i = 0; i < length; i++) {
            pass += chars.charAt(Math.floor(Math.random() * chars.length));
        }
        setPassword(pass);
    };

    const handleUsePassword = () => {
        const targetPath = formData?.id ? `/editar/${formData.id}` : "/editar";
        navigate(targetPath, {
            state: {
                generatedPassword: password,
                formData
            }
        });
    };

    const handleCopy = () => {
        if (password) {
            navigator.clipboard.writeText(password);
        }
    };

    const handleBack = () => {
        if (formData) {
            const targetPath = formData.id ? `/editar/${formData.id}` : "/editar";
            navigate(targetPath, { state: { formData } });
        } else {
            navigate("/home");
        }
    };

    return (
        <PageContainer
            title="Gerador de Senha"
            breadcrumbs={
                formData
                    ? [
                        { title: "Home", path: "/home" },
                        { title: "Editar Senha", path: "/editar" },
                        { title: "Gerador de Senha" }
                    ]
                    : [
                        { title: "Home", path: "/home" },
                        { title: "Gerador de Senha" }
                    ]
            }
            actions={
                <Button
                    label="Voltar"
                    type="button"
                    onClick={handleBack}
                    variant="cancelar"
                />
            }
        >
            <S.Container>
                <S.Section>
                    <S.SectionTitle>Senha Gerada</S.SectionTitle>
                    <S.PasswordBox>
                        <S.Password>{password || "Clique em 'Gerar Nova Senha'"}</S.Password>
                        <S.CopyButton
                            onClick={handleCopy}
                            disabled={!password}
                        >
                            📋 Copiar
                        </S.CopyButton>
                    </S.PasswordBox>
                </S.Section>

                <S.Section>
                    <S.SectionTitle>Opções de Geração</S.SectionTitle>
                    <S.Options>
                        <Checkbox
                            label="Maiúsculas (A-Z)"
                            checked={uppercase}
                            onChange={setUppercase}
                        />
                        <Checkbox
                            label="Minúsculas (a-z)"
                            checked={lowercase}
                            onChange={setLowercase}
                        />
                        <Checkbox
                            label="Números (0-9)"
                            checked={numbers}
                            onChange={setNumbers}
                        />
                        <Checkbox
                            label="Símbolos (!@#$...)"
                            checked={symbols}
                            onChange={setSymbols}
                        />
                    </S.Options>

                    <S.LengthControl>
                        <S.LengthLabel>
                            <span>Tamanho da Senha</span>
                            <S.LengthValue>{length} caracteres</S.LengthValue>
                        </S.LengthLabel>
                        <S.RangeInput
                            type="range"
                            min={6}
                            max={32}
                            value={length}
                            onChange={e => setLength(Number(e.target.value))}
                        />
                    </S.LengthControl>
                </S.Section>

                <S.Actions>
                    <Button
                        onClick={generatePassword}
                        label="🔄 Gerar Nova Senha"
                        type="button"
                        variant="ok"
                    />
                    {formData && (
                        <Button
                            onClick={handleUsePassword}
                            label="✓ Usar Esta Senha"
                            disabled={!password}
                        />
                    )}
                </S.Actions>
            </S.Container>
        </PageContainer>
    );
};

export default CreatePassword;
