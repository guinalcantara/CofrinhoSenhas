import { Link } from "react-router-dom";
import Input from "../../components/GenericComponents/Input";
import Button from "../../components/GenericComponents/Button";
import Card from "../../components/GenericComponents/Card";
import { useLogin } from "./useLogin";
import { useTheme } from "../../contexts/ThemeContext";
import * as S from "./styles";

function Login() {
    const { username, setUsername, password, setPassword, handleSubmit } = useLogin();
    const { themeMode, toggleTheme } = useTheme();

    return (
        <S.Container>
            <S.ThemeToggle
                onClick={toggleTheme}
                aria-label="Toggle theme"
                title={`Mudar para modo ${themeMode === 'light' ? 'escuro' : 'claro'}`}
            >
                {themeMode === 'light' ? '🌙' : '☀️'}
            </S.ThemeToggle>
            <Card customStyle={{ maxWidth: '450px', width: '100%' }}>
                <S.Logo>🔐</S.Logo>
                <S.Title>KeyBox</S.Title>
                <S.Subtitle>Gerencie suas senhas com segurança</S.Subtitle>

                <S.Form onSubmit={handleSubmit}>
                    <Input
                        showPlaceholderLabel={true}
                        name="username"
                        placeholder="E-mail"
                        type="text"
                        value={username}
                        onChange={setUsername}
                    />

                    <Input
                        showPlaceholderLabel={true}
                        name="password"
                        placeholder="Senha"
                        type="password"
                        value={password}
                        onChange={setPassword}
                    />

                    <Button
                        style={{ width: "100%" }}
                        label="Entrar"
                        type="submit"
                    />

                    <S.RegisterLink>
                        Não tem uma conta? <Link to="/registrar">Criar conta</Link>
                    </S.RegisterLink>
                </S.Form>

                <S.FeaturesGrid>
                    <S.Feature>
                        <S.FeatureIcon>🔒</S.FeatureIcon>
                        <S.FeatureText>Criptografia</S.FeatureText>
                    </S.Feature>
                    <S.Feature>
                        <S.FeatureIcon>⚡</S.FeatureIcon>
                        <S.FeatureText>Rápido</S.FeatureText>
                    </S.Feature>
                    <S.Feature>
                        <S.FeatureIcon>🛡️</S.FeatureIcon>
                        <S.FeatureText>Seguro</S.FeatureText>
                    </S.Feature>
                </S.FeaturesGrid>
            </Card>
        </S.Container>
    );
}

export default Login;
