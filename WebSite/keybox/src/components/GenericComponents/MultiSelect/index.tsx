import { useState, useRef, useEffect } from "react";
import type { MultiSelectProps } from "./types";
import Checkbox from "../Checkbox";
import * as S from "./styles";

const MultiSelect = ({
    value,
    options,
    onChange,
    placeholder = "Selecione...",
    disabled = false,
    className = "",
    label,
    searchable = false,
}: MultiSelectProps) => {
    const [isOpen, setIsOpen] = useState(false);
    const [searchTerm, setSearchTerm] = useState("");
    const containerRef = useRef<HTMLDivElement>(null);

    const handleToggle = (optionValue: string | number) => {
        if (value.includes(optionValue)) {
            onChange(value.filter(v => v !== optionValue));
        } else {
            onChange([...value, optionValue]);
        }
    };

    const handleClear = (e: React.MouseEvent) => {
        e.stopPropagation();
        onChange([]);
    };

    const getSelectedLabels = () => {
        if (value.length === 0) return placeholder;
        if (value.length === 1) {
            const selected = options.find(opt => opt.value === value[0]);
            return selected?.label || placeholder;
        }
        return `${value.length} itens selecionados`;
    };

    const filteredOptions = searchable
        ? options.filter(opt =>
            opt.label.toLowerCase().includes(searchTerm.toLowerCase())
        )
        : options;

    useEffect(() => {
        const handleClickOutside = (event: MouseEvent) => {
            if (containerRef.current && !containerRef.current.contains(event.target as Node)) {
                setIsOpen(false);
                setSearchTerm("");
            }
        };

        document.addEventListener("mousedown", handleClickOutside);
        return () => document.removeEventListener("mousedown", handleClickOutside);
    }, []);

    return (
        <S.Container ref={containerRef} className={className}>
            {label && (
                <S.SelectButton
                    as="label"
                    $isOpen={false}
                    $hasValue={false}
                    style={{
                        border: 'none',
                        padding: '0 0 0.5rem 0',
                        cursor: 'default',
                        fontWeight: 500,
                        fontSize: '0.875rem'
                    }}
                >
                    {label}
                </S.SelectButton>
            )}
            <S.SelectButton
                type="button"
                onClick={() => !disabled && setIsOpen(!isOpen)}
                disabled={disabled}
                $isOpen={isOpen}
                $hasValue={value.length > 0}
            >
                <S.SelectText>{getSelectedLabels()}</S.SelectText>
                <div style={{ display: 'flex', alignItems: 'center', gap: '0.5rem' }}>
                    {value.length > 0 && !disabled && (
                        <>
                            <S.SelectedCount>{value.length}</S.SelectedCount>
                            <S.ClearButton
                                type="button"
                                onClick={handleClear}
                                title="Limpar seleção"
                            >
                                ✕
                            </S.ClearButton>
                        </>
                    )}
                    <S.Arrow $isOpen={isOpen}>▼</S.Arrow>
                </div>
            </S.SelectButton>

            <S.Dropdown $isOpen={isOpen}>
                {searchable && (
                    <S.SearchInput
                        type="text"
                        placeholder="Buscar..."
                        value={searchTerm}
                        onChange={(e) => setSearchTerm(e.target.value)}
                        onClick={(e) => e.stopPropagation()}
                    />
                )}
                {filteredOptions.length === 0 ? (
                    <S.NoOptions>Nenhuma opção encontrada</S.NoOptions>
                ) : (
                    filteredOptions.map(opt => (
                        <S.OptionItem
                            key={opt.value}
                            $isHovered={false}
                            onClick={(e) => {
                                e.preventDefault();
                                e.stopPropagation();
                                if (!disabled) {
                                    handleToggle(opt.value);
                                }
                            }}
                            onMouseDown={(e) => {
                                e.preventDefault();
                            }}
                        >
                            <div style={{ pointerEvents: 'none', width: '100%' }}>
                                <Checkbox
                                    label={opt.label}
                                    checked={value.includes(opt.value)}
                                    onChange={() => { }}
                                    disabled={disabled}
                                />
                            </div>
                        </S.OptionItem>
                    ))
                )}
            </S.Dropdown>
        </S.Container>
    );
};

export default MultiSelect;
export type { MultiSelectProps, MultiSelectOption } from './types';
