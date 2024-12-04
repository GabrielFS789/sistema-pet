import moment from "moment/moment"

export function getDataHora(dataHoraString: string): string {
    return moment(dataHoraString).format('DD/MM/YYYY HH:mm:ss')
}