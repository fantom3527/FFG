import { useState } from 'react';
import { Button, Stack, Grid, TextField } from '@mui/material'
import { Input, Modal } from '@mui/joy'
import { CodeValue } from "./api/CodeValues/CodeValueModels"
import { Client } from "./api/CodeValues/CodeValueApi"
import CodeValueTable from "./components/Tables/CodeValueTable"

//TODO: Убрать в другое место
const apiClient = new Client('https://localhost:7083');

function App() {
  const handleButtonClickUpdate = async () => { 
    const newCodeValues = await apiClient.codeValueAll(filter)
    
    setCodeValues(newCodeValues)
  }

  const handleButtonClickSaveCodeValues = async () => {
    await apiClient.codeValue(codeValues)
  }

  const handleButtonClickSave = () => {
    if (newCodeValue.code == null || newCodeValue.value == null) {
      return
    }

    setCodeValues([...codeValues, newCodeValue]);
    setNewCodeValue({ id: newCodeValue.id + 1, code: undefined, value: undefined });
    setOpen(false);
  };

  const [codeValues, setCodeValues] = useState<CodeValue[]>([])  
  const [open, setOpen] = useState(false)
  const [filter, setFilter] = useState('');
  const [newCodeValue, setNewCodeValue] = useState<CodeValue>({ id: 0, code: undefined, value: undefined });

  return (
    <div className="App">
      <Grid container spacing={3}>
        <Grid item xs={7}>
          <CodeValueTable codeValues={codeValues} setCodeValues={setCodeValues}/>
        </Grid>
        <Grid item xs={5}>
          <Stack direction="column" spacing={2}>
            <Input placeholder="Filter.." variant="outlined" size="md" color="primary" value={filter} onChange={e => setFilter(e.target.value)}/>
            <Button variant="outlined" onClick={handleButtonClickUpdate} color='warning'>Обновить</Button>
            <Button variant="outlined" color='primary' onClick={() => setOpen(true)}>Добавить</Button>
            <Button variant="outlined" color="success" onClick={handleButtonClickSaveCodeValues}>Сохранить</Button>
          </Stack>

          <Modal open={open} onClose={() => setOpen(false)}>
            <Stack sx={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', bgcolor: 'background.paper', boxShadow: 24, p: 4, borderRadius: 1, maxWidth: 400 }}>
              <TextField label="Code" value={newCodeValue.code} onChange={(e) => setNewCodeValue({ ...newCodeValue, code: parseInt(e.target.value) })} />
              <TextField label="Value" value={newCodeValue.value} onChange={(e) => setNewCodeValue({ ...newCodeValue, value: e.target.value })} />
              <Button variant="outlined" color="success" onClick={handleButtonClickSave}>Сохранить</Button>
              <Button variant="outlined" color="error" onClick={() => setOpen(false)}>Отмена</Button>
            </Stack>
          </Modal>
        </Grid> 
      </Grid>
    </div>
  );
}

export default App;
