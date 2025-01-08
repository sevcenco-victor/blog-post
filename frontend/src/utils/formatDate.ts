import dayjs from 'dayjs';

export const formatDate = (date: string) => {
    return dayjs(date).format('dddd, D MMM YYYY');
}
export const formatEditDate = (date: string) => {
    return dayjs(date).format('D MMM HH:MM A');
}