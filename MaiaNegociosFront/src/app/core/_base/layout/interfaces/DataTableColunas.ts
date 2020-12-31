export interface DataTableColunas {
    propriedade: string;
    titulo: string;
    valor?: (row) => string;
    disabled: boolean;
    cell: (row) => string;
}
