import { Button, TableContainer, Paper, Table, TableHead, TableCell, TableBody, TableRow } from '@mui/material'
import { CodeValue } from "../../api/CodeValues/CodeValueModels"

interface CodeValuesProps {
    codeValues: CodeValue[],
    setCodeValues: React.Dispatch<React.SetStateAction<CodeValue[]>>;
}

const CodeValueTable: React.FC<CodeValuesProps> = ({ codeValues, setCodeValues }) => {

const handleDelete = (id: number) => {
    const updatedCodeValues = codeValues.filter((value) => value.id !== id);
    setCodeValues(updatedCodeValues);
}
    return (
        <TableContainer component={Paper}>
            <Table>
                <TableHead>
                    <TableCell>Порядковый номер</TableCell>
                    <TableCell>Код</TableCell>
                    <TableCell>Значение</TableCell>
                </TableHead>
                <TableBody>
                    {codeValues.map((row, index) => (
                            <TableRow key={row.id}>
                            <TableCell>{index + 1}</TableCell>
                            <TableCell>{row.code}</TableCell>
                            <TableCell>{row.value}</TableCell>
                            <TableCell>
                                <Button color="secondary" onClick={() => handleDelete(row.id)}>Удалить</Button>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
}

export default CodeValueTable