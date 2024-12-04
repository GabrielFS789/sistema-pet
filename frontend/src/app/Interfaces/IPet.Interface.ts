export interface IPet {
    id: number;
    inativo: boolean
    donoEndereco: string;
    donoNumeroEndereco?: string;
    donoComplemento?: string;
    donoTelefone?: string;
    donoNome: string;
    petNome: string;
    petSexo: string;
    petNascimento: string;
    racaId: string;
    doencas?: string;
    fraturas?: string| null;
    medos?: string | null;
    gestante: boolean;
    DataHoraCadastro: string;
    DataHoraUltimaAtualizacao?: string;
    imagemUrl?: string | null;
}