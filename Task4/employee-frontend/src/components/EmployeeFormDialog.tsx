import { Dialog, DialogContent, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Select, SelectTrigger, SelectValue, SelectContent, SelectItem } from "@/components/ui/select";
import { useEffect, useState } from "react";

type Props = {
  open: boolean;
  onClose: () => void;
  onSave: (data: any) => void;
  employee?: any;
  positions: any[];
};

export default function EmployeeFormDialog({ open, onClose, onSave, employee, positions }: Props) {
  const [form, setForm] = useState({
    fullName: "",
    dateOfBirth: "",
    hiredAt: "",
    positionId: 1
  });

  useEffect(() => {
    if (employee) {
      setForm({
        fullName: employee.fullName,
        dateOfBirth: employee.dateOfBirth.slice(0, 10),
        hiredAt: employee.hiredAt.slice(0, 10),
        positionId: positions.find(p => p.name === employee.position)?.id || 1
      });
    } else {
      setForm({ fullName: '', dateOfBirth: '', hiredAt: '', positionId: 1 });
    }
  }, [employee, positions]);

  return (
    <Dialog open={open} onOpenChange={onClose}>
      <DialogContent className="space-y-4">
        <DialogHeader>
          <DialogTitle>{employee ? "Редактировать" : "Создать"} сотрудника</DialogTitle>
        </DialogHeader>
        <div className="space-y-2">
          <Label>Ф.И.О</Label>
          <Input value={form.fullName} onChange={e => setForm({ ...form, fullName: e.target.value })} />

          <Label>Дата рождения</Label>
          <Input type="date" value={form.dateOfBirth} onChange={e => setForm({ ...form, dateOfBirth: e.target.value })} />

          <Label>Дата устройства</Label>
          <Input type="date" value={form.hiredAt} onChange={e => setForm({ ...form, hiredAt: e.target.value })} />

          <Label>Должность</Label>
          <Select value={form.positionId.toString()} onValueChange={(v: string) => setForm({ ...form, positionId: parseInt(v) })}>
            <SelectTrigger><SelectValue /></SelectTrigger>
            <SelectContent>
              {positions.map(p => <SelectItem key={p.id} value={p.id.toString()}>{p.name}</SelectItem>)}
            </SelectContent>
          </Select>
        </div>
        <div className="flex justify-end gap-2">
          <Button variant="outline" onClick={onClose}>Отмена</Button>
          <Button onClick={() => onSave(form)}>Сохранить</Button>
        </div>
      </DialogContent>
    </Dialog>
  );
}