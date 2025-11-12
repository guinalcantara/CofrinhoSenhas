import { Link } from "react-router-dom";
import { useMemo } from "react";
import Input from "../../components/GenericComponents/Input";
import Button from "../../components/GenericComponents/Button";
import Card from "../../components/GenericComponents/Card";
import { useRegister } from "./useRegister";
import { useTheme } from "../../contexts/ThemeContext";
import * as S from "./styles";

function Register() {
    const {
        nome,
        setNome,
        email,
        setEmail,
        senha,
        setSenha,
        handleSubmit,
        loading,
    } = useRegister();
    const { themeMode, toggleTheme } = useTheme();

    const passwordStrength = useMemo(() => {
        if (!senha) return { level: 'none' as const, text: '' };

        let strength = 0;
        if (senha.length >= 8) strength++;
        if (senha.length >= 12) strength++;
        if (/[a-z]/.test(senha) && /[A-Z]/.test(senha)) strength++;
        if (/\d/.test(senha)) strength++;
        if (/[^a-zA-Z0-9]/.test(senha)) strength++;

        if (strength <= 2) return { level: 'weak' as const, text: '⚠️ Senha fraca' };
        if (strength <= 4) return { level: 'medium' as const, text: '⚡ Senha média' };
        return { level: 'strong' as const, text: '✓ Senha forte' };
    }, [senha]);

    return (
        <S.Container>
            <S.ThemeToggle
                onClick={toggleTheme}
                aria-label="Toggle theme"
                title={`Mudar para modo ${themeMode === 'light' ? 'escuro' : 'claro'}`}
            >
                {themeMode === 'light' ? '🌙' : '☀️'}
            </S.ThemeToggle>
            <Card customStyle={{ maxWidth: '500px', width: '100%' }}>
                <S.Header>
                    <S.Logo>🔐</S.Logo>
                    <S.Title>Criar Conta</S.Title>
                    <S.Subtitle>Junte-se ao KeyBox e proteja suas senhas</S.Subtitle>
                </S.Header>

                <S.Form onSubmit={handleSubmit}>
                    <Input
                        showPlaceholderLabel={true}
                        name="nome"
                        placeholder="Nome completo"
                        type="text"
                        value={nome}
                        onChange={setNome}
                    />

                    <Input
                        showPlaceholderLabel={true}
                        name="email"
                        placeholder="E-mail"
                        type="text"
                        value={email}
                        onChange={setEmail}
                    />

                    <div>
                        <Input
                            showPlaceholderLabel={true}
                            name="senha"
                            placeholder="Senha"
                            type="password"
                            value={senha}
                            onChange={setSenha}
                        />
                        {senha && passwordStrength.level !== 'none' && (
                            <>
                                <S.PasswordStrength $level={passwordStrength.level}>
                                    {passwordStrength.text}
                                </S.PasswordStrength>
                                <S.StrengthBar>
                                    <S.StrengthFill $level={passwordStrength.level} />
                                </S.StrengthBar>
                            </>
                        )}
                    </div>

                    <S.Requirements>
                        <S.RequirementTitle>A senha deve conter:</S.RequirementTitle>
                        <S.RequirementList>
                            <S.RequirementItem>Mínimo de 8 caracteres</S.RequirementItem>
                            <S.RequirementItem>Letras maiúsculas e minúsculas</S.RequirementItem>
                            <S.RequirementItem>Números e símbolos</S.RequirementItem>
                        </S.RequirementList>
                    </S.Requirements>

                    <Button
                        style={{ width: "100%" }}
                        label={loading ? "Cadastrando..." : "Criar Conta"}
                        type="submit"
                        disabled={loading}
                    />

                    <Link to="/login" style={{ textDecoration: 'none' }}>
                        <S.BackLink>← Já tem uma conta? Faça login</S.BackLink>
                    </Link>
                </S.Form>

                <S.BenefitsGrid>
                    <S.Benefit>
                        <S.BenefitIcon>🔒</S.BenefitIcon>
                        <S.BenefitText>Armazenamento Seguro</S.BenefitText>
                    </S.Benefit>
                    <S.Benefit>
                        <S.BenefitIcon>🌐</S.BenefitIcon>
                        <S.BenefitText>Acesso em Qualquer Lugar</S.BenefitText>
                    </S.Benefit>
                    <S.Benefit>
                        <S.BenefitIcon>⚡</S.BenefitIcon>
                        <S.BenefitText>Geração Automática</S.BenefitText>
                    </S.Benefit>
                    <S.Benefit>
                        <S.BenefitIcon>📱</S.BenefitIcon>
                        <S.BenefitText>Multi-dispositivo</S.BenefitText>
                    </S.Benefit>
                </S.BenefitsGrid>
            </Card>
        </S.Container>
    );
}

export default Register;
